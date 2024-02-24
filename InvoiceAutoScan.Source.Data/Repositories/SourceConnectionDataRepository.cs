using InvoiceAutoScan.Common.Data.Repository;
using InvoiceAutoScan.Source.Core.Data.Connections;
using InvoiceAutoScan.Source.Core.Data.SourceConnections;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAutoScan.Source.Data.Repositories
{
    public class SourceConnectionDataRepository : BaseDataRepository<SourceConnection>, ISourceConnectionDataRepository
    {
        private readonly CommonSourceDataContext dbContext;

        public SourceConnectionDataRepository(CommonSourceDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override DbSet<SourceConnection> GetDbSet()
            => this.dbContext.Connections;
    }
}
