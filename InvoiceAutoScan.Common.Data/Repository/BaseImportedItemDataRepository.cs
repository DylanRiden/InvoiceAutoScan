using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Common.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Data.Repository
{
    public abstract class BaseImportedItemDataRepository<T, TSourceId> : BaseDataRepository<T>, IImportedItemDataRepository<T, TSourceId>
        where T: BaseImportedItemModel<TSourceId> 
    {
        protected BaseImportedItemDataRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<T> GetBySourceIdAsync(TSourceId sourceId)
            => await GetDbSet().SingleOrDefaultAsync(e => e.SourceId.Equals(sourceId));
    }
}
