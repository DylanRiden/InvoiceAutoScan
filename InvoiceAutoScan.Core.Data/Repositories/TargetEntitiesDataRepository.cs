using InvoiceAutoScan.Common.Data.Repository;
using InvoiceAutoScan.Core.TargetEntities;
using InvoiceAutoScan.Core.TargetEntities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Data.Repositories
{
    public sealed class TargetEntitiesDataRepository : BaseDataRepository<TargetEntity>, ITargetEntityDataRepository
    {
        private readonly CoreDataContext dbContext;

        public TargetEntitiesDataRepository(CoreDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override DbSet<TargetEntity> GetDbSet()
            => this.dbContext.TargetEntities;
    }
}
