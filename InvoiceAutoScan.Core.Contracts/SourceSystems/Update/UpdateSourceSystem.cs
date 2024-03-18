using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.SourceSystems.Update
{
    public record UpdateSourceSystem
    {
        public Guid Id { get; init; }
    }
}
