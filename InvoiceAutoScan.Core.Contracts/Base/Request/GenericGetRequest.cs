using InvoiceAutoScan.Common.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.Base.Request
{
    public class GenericGetRequest<TEntity>
        where TEntity: BaseModel
    {
        public Guid Id { get; set; }
    }
}
