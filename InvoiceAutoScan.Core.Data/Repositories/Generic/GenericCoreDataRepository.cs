using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Common.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Data.Repositories.Generic;

public sealed class GenericCoreDataRepository<TEntity> : BaseDataRepository<TEntity>
    where TEntity : BaseModel
{
    private readonly DbContext dbContext;

    public GenericCoreDataRepository(CoreDataContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    protected override DbSet<TEntity> GetDbSet()
    {
        var dbSet = dbContext.Set<TEntity>();

        if (dbSet is null)
            throw new Exception("DB Set Not Found");

        return dbSet;
    }
}
