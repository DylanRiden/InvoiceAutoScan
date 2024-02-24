using InvoiceAutoScan.Core.Contracts.TargetEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.DetectionEngine.Core.Detections.Models
{
    public class DetectionResult
    {
        public decimal Certainty { get; set; }

        public TargetEntityType Type { get; set; }
    }
}
