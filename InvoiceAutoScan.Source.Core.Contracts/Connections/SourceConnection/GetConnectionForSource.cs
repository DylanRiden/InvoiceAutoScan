using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection
{
    public record GetConnectionForSource
    {
        public Guid SourceId { get; init; }
    }
}
