using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Core.Contracts.TargetEntities;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.TargetEntities.Consumers
{
    public sealed class CreateTargetEntityConsumer : IConsumer<CreateTargetEntity>
    {
        private readonly ILogger<CreateTargetEntityConsumer> logger;
        private readonly IDataRepository<TargetEntity> targetEntityDataRepository;

        public CreateTargetEntityConsumer(ILogger<CreateTargetEntityConsumer> logger,
            IDataRepository<TargetEntity> targetEntityDataRepository)
        {
            this.logger = logger;
            this.targetEntityDataRepository = targetEntityDataRepository;
        }

        public async Task Consume(ConsumeContext<CreateTargetEntity> context)
        {
            CreateTargetEntity createEntityDto = context.Message;

            TargetEntity entity = new()
            {
                PublishedDate = DateTime.UtcNow,
                Type = createEntityDto.Type,
                Description = createEntityDto.Description,
                Identifier = createEntityDto.Identifier,
                ItemId = createEntityDto.ItemId,
                SourceSystemId = createEntityDto.SourceSystemId,
                Certainty = createEntityDto.Certainty
            };

            await this.targetEntityDataRepository.CreateAsync(entity);

        }
    }
}
