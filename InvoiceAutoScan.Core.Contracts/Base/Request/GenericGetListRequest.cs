using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Common.Query;

namespace InvoiceAutoScan.Core.Contracts.Base.Request;

public class GenericGetListRequest<TEntity>
    where TEntity : BaseModel
{
    public QueryParams Query { get; set; }
    
    //TODO: Filters :)
}