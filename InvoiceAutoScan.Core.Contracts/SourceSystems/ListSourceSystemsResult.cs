using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.SourceSystems
{
    public class ListSourceSystemsResult
    {
        public List<SourceSystemResult> Data { get; set; }

        public int Count => Data.Count;
    }
}
