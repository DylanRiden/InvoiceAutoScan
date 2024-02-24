using InvoiceAutoScan.Core.Contracts.SourceSystems;
using InvoiceAutoScan.Core.SourceSystems.Data;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.SourceSystems.Consumers
{
    public class CreateSourceSystemConsumer : IConsumer<CreateSourceSystem>
    {
        private readonly ISourceSystemsDataRepository dataRepository;

        public CreateSourceSystemConsumer(ISourceSystemsDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task Consume(ConsumeContext<CreateSourceSystem> context)
        {
            SourceSystem sourceSystem = new()
            {
                Id = Guid.NewGuid(),
                SystemName = context.Message.SystemName,
                DisplayName = context.Message.DisplayName,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
            };

            var source = await this.dataRepository.CreateAsync(sourceSystem);
            await context.RespondAsync<SourceSystemResult>(new
            {
                source.Id,
                source.DisplayName,
                source.SystemName,
                source.CreatedDate,
                source.ModifiedDate
            });
        }
    }
}
