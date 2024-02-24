using Google.Apis.Gmail.v1.Data;
using InvoiceAutoScan.Common.Helpers;
using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using InvoiceAutoScan.Source.Gmail.Contracts.Messages;
using InvoiceAutoScan.Source.Gmail.Contracts.Sync;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace InvoiceAutoScan.Source.Gmail.Consumers.Sync
{
    public class GmailProcessMessageConsumer : IConsumer<ProcessGmailMessage>
    {
        private readonly ILogger<GmailProcessMessageConsumer> logger;
        private readonly GmailApiContext context;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IRequestClient<GetImportedMessageBySourceId> getImportedMessageClient;

        public GmailProcessMessageConsumer(ILogger<GmailProcessMessageConsumer> logger,
            GmailApiContext container,
            IPublishEndpoint publishEndpoint,
            IRequestClient<GetImportedMessageBySourceId> getImportedMessageClient)
        {
            this.logger = logger;
            this.context = container;
            this.publishEndpoint = publishEndpoint;
            this.getImportedMessageClient = getImportedMessageClient;
        }

        public async Task Consume(ConsumeContext<ProcessGmailMessage> context)
        {
            ProcessGmailMessage gmailMessage = context.Message;

            Message message = 
                await this.context.GmailService.Users.Messages.Get("me", gmailMessage.MessageId).ExecuteAsync();

            string sourceId = message.Id;
            Response<ImportedMessageResult,  ImportedMessageNotFound> existingResponse = 
                await getImportedMessageClient.GetResponse<ImportedMessageResult, ImportedMessageNotFound>
                (new GetImportedMessageBySourceId() { SourceId = sourceId, SourceSystemId = this.context.SourceSystem.Id });

            if (existingResponse.Is<ImportedMessageNotFound>(out _))
            {
                await this.publishEndpoint.Publish(Map(message));
            }
            else
            {
                this.logger.LogInformation("Message Already Exists");
            }
            

        }

        //create insert message... do emails get updated? Threads do, then after that, process to see if it is an invoice

        private CreateImportedMessage Map(Message message)
        {
            string subject = message.Payload.Headers.Where(e => e.Name == "Subject").Select(e => e.Value).Single();
            string from = message.Payload.Headers.Where(e => e.Name == "From").Select(e => e.Value).Single();

            return new CreateImportedMessage()
            {
                Subject = subject,
                From = from,
                HistoryId = message.HistoryId.GetValueOrDefault(),
                InternalDate = DateHelper.FromEpochToUTC(message.InternalDate.GetValueOrDefault()),
                SourceId = message.Id,
                SourceSystemId = this.context.SourceSystem.Id
            };
        }
    }
}
