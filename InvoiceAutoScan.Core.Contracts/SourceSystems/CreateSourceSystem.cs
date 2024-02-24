using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.SourceSystems
{
    public record CreateSourceSystem
    {
        public string SystemName { get; init; }
        public string DisplayName { get; init; }

    }
}
