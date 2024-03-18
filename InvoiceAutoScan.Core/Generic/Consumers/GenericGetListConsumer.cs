using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Core.Contracts.Base.Request;
using MassTransit;

namespace InvoiceAutoScan.Core.Generic.Consumers;

public class GenericGetListConsumer<TEntity> : IConsumer<GenericGetListRequest<TEntity>>
    where TEntity : BaseModel
{
    private readonly IDataRepository<TEntity> _dataRepository;

    public GenericGetListConsumer(IDataRepository<TEntity> dataRepository)
    {
        _dataRepository = dataRepository;
    }
    
    
    public Task Consume(ConsumeContext<GenericGetListRequest<TEntity>> context)
    {
        
        
        
        throw new NotImplementedException();
    }
}