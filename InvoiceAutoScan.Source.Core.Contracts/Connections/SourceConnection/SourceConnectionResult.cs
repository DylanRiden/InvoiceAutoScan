using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection
{

    public record SourceConnectionResult
    {
        public Guid Id { get; init; }
        public Guid SourceId { get; init; }

        public IDictionary<string, object> ConnectionSettings { get; init; }
    }
}
