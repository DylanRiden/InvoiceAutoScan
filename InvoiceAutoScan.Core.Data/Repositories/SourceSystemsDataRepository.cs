using InvoiceAutoScan.Common.Data.Repository;
using InvoiceAutoScan.Core.SourceSystems;
using InvoiceAutoScan.Core.SourceSystems.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Data.Repositories
{
    public sealed class SourceSystemsDataRepository : BaseDataRepository<SourceSystem>, ISourceSystemsDataRepository
    {
        private readonly CoreDataContext dbContext;
        
        public SourceSystemsDataRepository(CoreDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override DbSet<SourceSystem> GetDbSet()
        {
            return dbContext.SourceSystems;
        }
    }
}
