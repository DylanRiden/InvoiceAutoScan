using InvoiceAutoScan.Common.Abstractions.Detection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.DetectionEngine.Contracts
{
    public record DetectItemMessage
    {
        public IDetectableItem Item { get; init; }
    }
}
