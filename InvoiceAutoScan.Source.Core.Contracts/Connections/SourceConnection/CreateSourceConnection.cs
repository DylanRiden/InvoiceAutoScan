using InvoiceAutoScan.Source.Common;

namespace InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection
{
    public record CreateSourceConnection
    {
        public Guid SourceSystemId { get; set; }

        public SourceConnectionType ConnectionType { get; set; }

        public IDictionary<string, object>? ConnectionSettings { get; set; }
    }
}
