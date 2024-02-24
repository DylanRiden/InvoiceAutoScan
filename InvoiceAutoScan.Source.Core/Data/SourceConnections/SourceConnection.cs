using InvoiceAutoScan.Common.Accessors;
using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Source.Common;

namespace InvoiceAutoScan.Source.Core.Data.SourceConnections
{
    public class SourceConnection : BaseModel
    {
        public Guid SourceId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public SourceConnectionType ConnectionType { get; set; }

        public string? ConnectionSettingsJson { get; set; }
    }
}
