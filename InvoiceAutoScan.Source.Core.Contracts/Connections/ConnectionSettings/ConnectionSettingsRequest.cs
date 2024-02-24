using InvoiceAutoScan.Source.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Contracts.Connections.ConnectionSettings
{
    public record ConnectionSettingsRequest
    {
        public SourceConnectionType SourceConnectionType { get; init; }
        public IDictionary<string, object> ConnectionSettings { get; init; }
    }
}
