using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.SourceSystems
{
    public record SourceSystemStatusResult
    {
        public bool Connected { get; init; }
        public DateTime LastRan { get; set; }
    }
}
