using InvoiceAutoScan.DetectionEngine.Contracts;
using InvoiceAutoScan.Source.Gmail.Contracts.Messages;
using InvoiceAutoScan.Source.Gmail.Models.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Consumers.Messages
{
    public class CreateImportedMessageConsumer : IConsumer<CreateImportedMessage>
    {
        private readonly IImportedMessagesRepository dataRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public CreateImportedMessageConsumer(IImportedMessagesRepository dataRepository,
            IPublishEndpoint publishEndpoint)
        {
            this.dataRepository = dataRepository;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<CreateImportedMessage> context)
        {
            ImportedMessage response = await dataRepository.CreateAsync(Map(context.Message));

            DetectItemMessage message = new()
            {
                Item = response
            };

            await this.publishEndpoint.Publish(message);
        }

        private ImportedMessage Map(CreateImportedMessage dto)
        {
            return new()
            {
                SourceId = dto.SourceId,
                From = dto.From,
                HistoryId = dto.HistoryId,
                Id = Guid.NewGuid(),
                InternalDate = dto.InternalDate.ToUniversalTime(),
                Subject = dto.Subject,
                SourceSystemId = dto.SourceSystemId
            };
        }
    }
}
