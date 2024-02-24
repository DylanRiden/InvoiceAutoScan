using Google.Apis.Gmail.v1.Data;
using Google.Apis.Requests;
using InvoiceAutoScan.Common.Helpers;
using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using InvoiceAutoScan.Source.Gmail.Contracts.Messages;
using InvoiceAutoScan.Source.Gmail.Contracts.Sync.ProcessBatchMessage;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Consumers.Sync
{
    public class GmailProcessBatchMessageConsumer : IConsumer<ProcessBatchGmailMessage>
    {
        private readonly GmailApiContext gmailContext;
        private readonly IPublishEndpoint publisher;

        private List<Message> GmailMessages { get; set; } = new List<Message>();

        public GmailProcessBatchMessageConsumer(GmailApiContext context,
            IPublishEndpoint publisher)
        {
            this.gmailContext = context;
            this.publisher = publisher;
        }

        public async Task Consume(ConsumeContext<ProcessBatchGmailMessage> context)
        {
            var request = new BatchRequest(gmailContext.GmailService);
            
            foreach(var item in context.Message.Messages)
            {
                request.Queue<Message>(gmailContext.GmailService.Users.Messages.Get("me", item.MessageId),
                    (content, error, i, message) =>
                    {
                        this.GmailMessages.Add(content);
                    
                    });
            }
            await request.ExecuteAsync();

            IEnumerable<CreateImportedMessage> createMessages = this.GmailMessages.Select(Map).Where(e => e is not null);
            await this.publisher.PublishBatch(createMessages);
        }

        private CreateImportedMessage Map(Message message)
        {
            if (message is null) return default;
            string subject = message.Payload.Headers.Where(e => e.Name == "Subject").Select(e => e.Value).SingleOrDefault();
            string from = message.Payload.Headers.Where(e => e.Name == "From").Select(e => e.Value).Single();

            return new CreateImportedMessage()
            {
                Subject = subject,
                From = from,
                HistoryId = message.HistoryId.GetValueOrDefault(),
                InternalDate = DateHelper.FromEpochToUTC(message.InternalDate.GetValueOrDefault()),
                SourceId = message.Id,
                SourceSystemId = this.gmailContext.SourceSystem.Id
            };
        }

    }
}
