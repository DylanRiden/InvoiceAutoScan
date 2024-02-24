using InvoiceAutoScan.Common.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Base.DataRepositories
{
    public interface IDataRepository<TModel>
        where TModel : BaseModel
    {
        public Task<TModel?> GetAsync(Guid id);
        public TModel? Get(Func<TModel, bool> predicate);
        public IQueryable<TModel> List();
        public Task<TModel> CreateAsync(TModel model);
        public Task<TModel> UpdateAsync(TModel model);
        public Task DeleteAsync(Guid id);
        public Task DeleteAsync(TModel model);
    }
}
