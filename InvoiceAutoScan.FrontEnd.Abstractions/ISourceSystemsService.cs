using InvoiceAutoScan.Core.Contracts.Base;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Create;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Update;

namespace InvoiceAutoScan.FrontEnd.Abstractions
{
    public interface ISourceSystemsService: IBaseService<CreateSourceSystem, UpdateSourceSystem, SourceSystemResult>
    {
        
    }
}
