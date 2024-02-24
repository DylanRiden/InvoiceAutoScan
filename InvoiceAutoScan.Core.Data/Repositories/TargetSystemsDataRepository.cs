using InvoiceAutoScan.Common.Data.Repository;
using InvoiceAutoScan.Core.TargetSystems;
using InvoiceAutoScan.Core.TargetSystems.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAutoScan.Core.Data.Repositories
{
    public class TargetSystemsDataRepository : BaseDataRepository<TargetSystem>, ITargetSystemsDataRepository
    {
        private readonly CoreDataContext dbContext;

        public TargetSystemsDataRepository(CoreDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override DbSet<TargetSystem> GetDbSet() => dbContext.TargetSystems;
    }
}
