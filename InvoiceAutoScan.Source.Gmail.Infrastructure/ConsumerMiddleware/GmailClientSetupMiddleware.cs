using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using InvoiceAutoScan.Common.Source.Options;
using InvoiceAutoScan.Core.Contracts.SourceSystems;
using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection;
using InvoiceAutoScan.Source.Gmail.Contracts.Sync;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Configuration;
using Microsoft.Extensions.Options;
using Google.Apis.Logging;
using Microsoft.Extensions.Logging;
using InvoiceAutoScan.Source.Gmail.Contracts;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.ConsumerMiddleware
{
    public class GmailClientSetupMiddleware<T>: IFilter<ConsumeContext<T>>
        where T: class
    {
        private readonly GmailApiContext apiClientContainer;
        private readonly IRequestClient<GetSourceSystem> requestSourceClient;
        private readonly IRequestClient<GetConnectionForSource> requestConnectionClient;
        private readonly ILogger<ConsumerMiddleware.GmailClientSetupMiddleware<T>> logger;
        private readonly GoogleCredentials googleCredentials;

        public GmailClientSetupMiddleware(GmailApiContext apiClientContainer,
            IRequestClient<GetSourceSystem> requestSourceClient,
            IRequestClient<GetConnectionForSource> requestConnectionClient,
            IOptions<GoogleCredentials> credentialOptions,
            ILogger<GmailClientSetupMiddleware<T>> logger)
        {
            this.apiClientContainer = apiClientContainer;
            this.requestSourceClient = requestSourceClient;
            this.requestConnectionClient = requestConnectionClient;
            this.logger = logger;
            this.googleCredentials = credentialOptions.Value;
        }

        public void Probe(ProbeContext context)
        {
            throw new NotImplementedException();
        }

        public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
        {
            if(context.Message is IGmailTaskMessage trigger)
            {
                Guid sourceId = trigger.SourceSystemId;

                Response<SourceSystemResult, SourceSystemNotFound> sourceSystemResponse = await this.requestSourceClient.GetResponse
                    <SourceSystemResult, SourceSystemNotFound>(new GetSourceSystem() { SourceSystemId = sourceId });

                Response<SourceSystemResult> sourceSystem;
                if (sourceSystemResponse.Is<SourceSystemResult>(out sourceSystem))
                {
                    //do nothing
                }
                else
                {
                    throw new Exception("SourceSystem Not Found");
                }

                this.apiClientContainer.SourceSystem = sourceSystem.Message;

                Response<SourceConnectionResult> connectionMessage = await this.requestConnectionClient.GetResponse<SourceConnectionResult>(new GetConnectionForSource() { SourceId = sourceSystem.Message.Id });

                SourceConnectionResult connection = connectionMessage.Message;

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
                {
                    ClientSecrets = new ClientSecrets()
                    {
                        ClientId = googleCredentials.ClientId,
                        ClientSecret = googleCredentials.ClientSecret
                    },
                    Scopes = new string[] { GmailService.ScopeConstants.GmailReadonly }
                });

                // Create a token response with the refresh token
                var token = new TokenResponse
                {
                    RefreshToken = connection.ConnectionSettings["RefreshToken"].ToString()
                };

                // Create a user credential with the flow and the token
                var credential = new UserCredential(flow, "user", token);

                await credential.RefreshTokenAsync(CancellationToken.None);

                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Invoice Auto Scan"
                });

                this.apiClientContainer.UserID = credential.UserId;
                this.apiClientContainer.GmailService = service;

                logger.LogInformation("Successful Authentication for GMAIL Service");
                logger.LogInformation($"GMAIL USERID: {this.apiClientContainer.UserID}");
            }

            await next.Send(context);
        }
    }
}
