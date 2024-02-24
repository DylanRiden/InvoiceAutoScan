using InvoiceAutoScan.Core.Contracts.TargetEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.TargetEntities
{
    public sealed record CreateTargetEntity
    {
        public TargetEntityType Type { get; init; }

        public string Description { get; init; }

        public Guid SourceSystemId { get; init; }

        public string Identifier { get; init; }

        public Guid ItemId { get; init; }

        public decimal Certainty { get; init; }
    }
}
