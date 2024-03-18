using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.Base
{
    public class IasListResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Count { get => Data.Count(); }
    }
}
