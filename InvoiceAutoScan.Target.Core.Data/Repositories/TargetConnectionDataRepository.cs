using InvoiceAutoScan.Common.Data.Repository;
using InvoiceAutoScan.Target.Core.Data.TargetConnections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Target.Core.Data.Repositories
{
    public class TargetConnectionDataRepository : BaseDataRepository<TargetConnection>, ITargetConnectionDataRepository
    {
        private readonly CommonTargetDataContext dbContext;

        public TargetConnectionDataRepository(CommonTargetDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override DbSet<TargetConnection> GetDbSet() => dbContext.TargetConnections;
    }
}
