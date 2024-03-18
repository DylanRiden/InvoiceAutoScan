using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Create;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;
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
        private readonly IDataRepository<SourceSystem> dataRepository;

        public CreateSourceSystemConsumer(IDataRepository<SourceSystem> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task Consume(ConsumeContext<CreateSourceSystem> context)
        {
            Console.WriteLine("TYYYYYYYPE");

            SourceSystem sourceSystem = new()
            {
                Id = Guid.NewGuid(),
                SystemName = context.Message.SystemName,
                DisplayName = context.Message.DisplayName,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            var source = await this.dataRepository.CreateAsync(sourceSystem);
            await context.RespondAsync<SourceSystemResult>(new()
            {
                Id = source.Id,
                DisplayName = source.DisplayName,
                SystemName = source.SystemName,
                SourceSystemType = "TODO: Type",
                CreatedDate = source.CreatedDate,
                ModifiedDate = source.ModifiedDate,
            });
        }
    }
}
