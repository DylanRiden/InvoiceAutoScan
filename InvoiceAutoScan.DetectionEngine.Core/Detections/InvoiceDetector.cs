using InvoiceAutoScan.Common.Abstractions.Detection;
using InvoiceAutoScan.Core.Contracts.TargetEntities.Enum;
using InvoiceAutoScan.DetectionEngine.Core.Detections.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.DetectionEngine.Core.Detections
{
    public class InvoiceDetector
    {
        private readonly ILogger<InvoiceDetector> logger;

        public InvoiceDetector(ILogger<InvoiceDetector> logger)
        {
            this.logger = logger;
        }

        public DetectionResult DetectInvoice(IDetectableItem item)
        {
            DetectionResult result = new();

            bool containsInvoice = item.Detail.Contains("Invoice");
            bool containsYourInvoice = containsInvoice && item.Detail.Contains("Your");


            if (item.HasFile && containsYourInvoice)
            {
                result.Certainty = 0.99m;
                result.Type = TargetEntityType.Invoice;
            }
            else if (containsYourInvoice)
            {
                result.Certainty = 0.80m;
                result.Type = TargetEntityType.Invoice;
            }
            else if (containsInvoice)
            {
                result.Certainty = 0.7m;
                result.Type = TargetEntityType.Invoice;
            }

            return result;
        }
    }
}
