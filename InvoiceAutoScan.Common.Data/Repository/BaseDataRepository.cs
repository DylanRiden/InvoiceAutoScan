using InvoiceAutoScan.Common.Accessors;
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
    public abstract class BaseDataRepository<T> : IDataRepository<T>
        where T : BaseModel
    {
        private readonly DbContext dbContext;

        public BaseDataRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected abstract DbSet<T> GetDbSet();

        public async Task<T> CreateAsync(T model)
        {
            GetDbSet().Add(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(Guid id)
            => await DeleteAsync(await GetDbSet().SingleAsync(e => e.Id == id));

        public async Task DeleteAsync(T model)
        {
            dbContext.Remove(model);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<T> List()
        {
            return GetDbSet().AsQueryable();
        }

        public async Task<T?> GetAsync(Guid id)
            => await GetDbSet().SingleOrDefaultAsync(e => e.Id == id);

        public T? Get(Func<T, bool> predicate) =>
            GetDbSet().Where(predicate).SingleOrDefault();


        public async Task<T> UpdateAsync(T model)
        {
            GetDbSet().Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}
