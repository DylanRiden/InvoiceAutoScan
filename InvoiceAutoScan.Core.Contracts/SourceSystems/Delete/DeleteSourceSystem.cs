using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.SourceSystems.Delete
{
    public record DeleteSourceSystem
    {
        public Guid Id { get; init; }
    }
}
