using InvoiceAutoScan.Common.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Base.DataRepositories
{
    public interface IImportedItemDataRepository<TModel, TSourceId>: IDataRepository<TModel>
        where TModel: BaseImportedItemModel<TSourceId>
    {
        public Task<TModel> GetBySourceIdAsync(TSourceId sourceId);
    }
}
