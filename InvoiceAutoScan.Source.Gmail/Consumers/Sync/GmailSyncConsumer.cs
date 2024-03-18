using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using InvoiceAutoScan.Common.Source.Options;
using InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection;
using InvoiceAutoScan.Source.Gmail.Contracts.Sync;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using MassTransit.Configuration;
using Microsoft.Extensions.Options;
using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using Google.Apis.Gmail.v1.Data;
using InvoiceAutoScan.Common.Helpers;
using InvoiceAutoScan.Source.Gmail.Contracts.Sync.ProcessBatchMessage;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;

namespace InvoiceAutoScan.Source.Gmail.Consumers.Sync
{
    public class GmailSyncConsumer : IConsumer<GmailSyncTrigger>
    {
        private readonly ILogger<GmailSyncConsumer> logger;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly GmailService service;
        private readonly SourceSystemResult sourceSystem;

        public GmailSyncConsumer(ILogger<GmailSyncConsumer> logger,
            GmailApiContext container,
            IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
            this.service = container.GmailService;
            this.sourceSystem = container.SourceSystem;
        }


        public async Task Consume(ConsumeContext<GmailSyncTrigger> context)
        {
            var request = this.service.Users.Messages.List("me");

            ListMessagesResponse currentResponse = await request.ExecuteAsync();

            request.MaxResults = 100;

            await LocallyProcessMessages(currentResponse.Messages);

            this.logger.LogInformation("Processed GMAIL Messages Page");

            while (!string.IsNullOrWhiteSpace(currentResponse.NextPageToken))
            {
                request.PageToken = currentResponse.NextPageToken;

                currentResponse = await request.ExecuteAsync();

                await LocallyProcessMessages(currentResponse.Messages);

                this.logger.LogInformation("Processed GMAIL Messages Page");
            }
        }

        private async Task LocallyProcessMessages(IList<Message> messages)
        {
            IEnumerable<ProcessMessageInfo> messagesToPublish = messages.Select(e => new ProcessMessageInfo()
            {
                MessageId = e.Id,
            });

            ProcessBatchGmailMessage message = new()
            {
                SourceSystemId = this.sourceSystem.Id,
                Messages = messagesToPublish
            };

            await this.publishEndpoint.Publish(message);
        }
    }
}
