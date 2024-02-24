using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Contracts.Connections.Trigger
{
    public record TriggerSourceSync
    {
        public Guid SourceId { get; init; }
    }
}
