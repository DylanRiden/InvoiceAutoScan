using InvoiceAutoScan.Core.Contracts.SourceSystems;
using InvoiceAutoScan.Core.SourceSystems.Data;
using MassTransit;

namespace InvoiceAutoScan.Core.SourceSystems.Consumers
{
    public class SourceSystemRequestConsumer : IConsumer<GetSourceSystem>, IConsumer<ListSourceSystems>
    {
        private readonly ISourceSystemsDataRepository dataRepository;

        public SourceSystemRequestConsumer(ISourceSystemsDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task Consume(ConsumeContext<GetSourceSystem> context)
        {
            SourceSystem? sourceSystem = await dataRepository.GetAsync(context.Message.SourceSystemId);
            
            if(sourceSystem is null)
                await context.RespondAsync(new SourceSystemNotFound() { SourceId = context.Message.SourceSystemId});
            else
            {
                SourceSystemResult result = MapToResult(sourceSystem);
                await context.RespondAsync(result);
            }
        }

        public async Task Consume(ConsumeContext<ListSourceSystems> context)
        {
            IQueryable<SourceSystem> sourceSystems = this.dataRepository.List();

            IQueryable<SourceSystemResult>results = sourceSystems.Select(e => MapToResult(e));

            ListSourceSystemsResult result = new()
            {
                Data = results.ToList()
            };

            await context.RespondAsync(result);
        }

        private static SourceSystemResult MapToResult(SourceSystem sourceSystem)
        =>
            new()
            {
                CreatedDate = sourceSystem.CreatedDate,
                Id = sourceSystem.Id,
                DisplayName = sourceSystem.DisplayName,
                SystemName = sourceSystem.SystemName,
                ModifiedDate = sourceSystem.ModifiedDate
            };
    }
}
