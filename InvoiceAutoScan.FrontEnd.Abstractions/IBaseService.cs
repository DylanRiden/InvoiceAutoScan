using InvoiceAutoScan.Core.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.FrontEnd.Abstractions
{
    public interface IBaseService<TCreateContract, TUpdateContract, TResultContract>
        where TCreateContract:class
        where TUpdateContract:class
        where TResultContract:class
    {
        public Task<IasResponse<TResultContract>> Create(TCreateContract value);

        public Task<IasResponse<TResultContract>> Update(TUpdateContract value);

        public Task<IasResponse> Delete(Guid id);

        public Task<IasResponse<TResultContract>> Get(Guid id);

        public Task<IasListResponse<TResultContract>> List(Func<IQueryable<TResultContract>, IQueryable<TResultContract>> listQuery);
    }
}
