using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.SourceSystems.Result
{
    public record SourceSystemResult
    {
        public Guid Id { get; init; }
        public string DisplayName { get; init; }
        public string SystemName { get; init; }
        public string SourceSystemType { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime ModifiedDate { get; init; }
    }
}
