using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Core.Contracts.TargetEntities.Enum;
using InvoiceAutoScan.Core.SourceSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.TargetEntities
{
    public sealed class TargetEntity : BaseModel
    {
        public DateTime? PublishedDate { get; set; }

        public TargetEntityType Type { get; set; }

        public string Description { get; set; }

        public string Identifier { get; set; }

        public decimal Certainty { get; set; } = 0.0m;

        //In this case this is our ID of the record about the item we imported
        public Guid ItemId { get; set; }

        public Guid? SourceSystemId { get; set; }

        //Navigation
        public SourceSystem? SourceSystem { get; set; }
    }
}
