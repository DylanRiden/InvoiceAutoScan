using Google.Apis.Logging;
using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using InvoiceAutoScan.Source.Gmail.Contracts;
using InvoiceAutoScan.Source.Gmail.Contracts.Messages;
using InvoiceAutoScan.Source.Gmail.Models.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;


namespace InvoiceAutoScan.Source.Gmail.Consumers.Messages
{
    public class GetImportedMessageConsumer : IConsumer<GetImportedMessage>,
        IConsumer<GetImportedMessageBySourceId>
    {
        private readonly ILogger<GetImportedMessageConsumer> logger;
        private readonly IImportedMessagesRepository dataRepository;
        private readonly GmailApiContext context;

        public GetImportedMessageConsumer(ILogger<GetImportedMessageConsumer> logger, 
            IImportedMessagesRepository dataRepository, GmailApiContext context)
        {
            this.logger = logger;
            this.dataRepository = dataRepository;
            this.context = context;
        }

        public async Task Consume(ConsumeContext<GetImportedMessageBySourceId> context)
        {
            var message = context.Message;

            ImportedMessage? importedMessage = await this.dataRepository.GetBySourceIdAsync(message.SourceId);
            
            if(importedMessage is null)
            {
                await context.RespondAsync(new ImportedMessageNotFound() { SourceId = message.SourceId });
            }
            else
            {
                await context.RespondAsync(MapToResult(importedMessage));
            }

        }

        public Task Consume(ConsumeContext<GetImportedMessage> context)
        {
            throw new NotImplementedException();
        }

        private ImportedMessageResult MapToResult(ImportedMessage importedMessage)
        {
            return new ImportedMessageResult()
            {
                HistoryId = importedMessage.HistoryId,
                Subject = importedMessage.Subject,
                Id = importedMessage.Id,
                InternalDate = importedMessage.InternalDate,
                SourceId = importedMessage.SourceId,
                SourceSystemId = this.context.SourceSystem.Id
            };
        }
    }
}
