using InvoiceAutoScan.Common.Abstractions.ConnectionSettings;
using InvoiceAutoScan.Source.Common;
using InvoiceAutoScan.Source.Core.Contracts.Connections.ConnectionSettings;
using InvoiceAutoScan.Source.Gmail.Contracts.ConnectionSettings;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Consumers.ConnectionSettings
{
    public sealed class ConnectionSettingsRequestConsumer : IConsumer<ConnectionSettingsRequest>
    {
        private readonly IRequestClient<GetGmailConnectionSettings> gmailRequestClient;

        public ConnectionSettingsRequestConsumer(IRequestClient<GetGmailConnectionSettings> gmailRequestClient)
        {
            this.gmailRequestClient = gmailRequestClient;
        }

        public async Task Consume(ConsumeContext<ConnectionSettingsRequest> context)
        {
            switch (context.Message.SourceConnectionType)
            {
                case SourceConnectionType.Gmail:
                    GetGmailConnectionSettings gmailRequest = new() { ConnectionSettings = context.Message.ConnectionSettings };
                    Response<ConnectionSettingsResult> response = await gmailRequestClient.GetResponse<ConnectionSettingsResult>(gmailRequest);
                    await context.RespondAsync(response.Message);
                    break;
                default:
                    throw new NotImplementedException("Connection Settings Request Not Implemented For :" + context.Message.SourceConnectionType);
            }
        }
    }
}
