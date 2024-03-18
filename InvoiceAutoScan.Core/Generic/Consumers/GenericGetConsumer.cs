using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Core.Contracts.Base;
using InvoiceAutoScan.Core.Contracts.Base.Request;
using InvoiceAutoScan.Core.Contracts.Base.Response;
using InvoiceAutoScan.Core.SourceSystems;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Generic.Consumers
{
    public class GenericGetConsumer<TEntity> : IConsumer<GenericGetRequest<TEntity>>
        where TEntity: BaseModel
    {
        private readonly IDataRepository<TEntity> _dataRepository;

        public GenericGetConsumer(IDataRepository<TEntity> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task Consume(ConsumeContext<GenericGetRequest<TEntity>> context)
        {
            TEntity? entity = await this._dataRepository.GetAsync(context.Message.Id);
            
            if(entity is null)
            {
                await context.RespondAsync(new IasNotFoundResponse());
            }
            else
            {
                await context.RespondAsync(entity);
            }

        }
    }
}
