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
    public class ReceiptDetector
    {
        private readonly ILogger<ReceiptDetector> logger;

        public ReceiptDetector(ILogger<ReceiptDetector> logger)
        {
            this.logger = logger;
        }

        public DetectionResult DetectReceipt(IDetectableItem item)
        {
            DetectionResult result = new();

            bool containsReceipt = item.Detail.Contains("Receipt");
            bool containsYourReceipt = containsReceipt && item.Detail.Contains("Your");
            

            if (item.HasFile && containsYourReceipt)
            {
                result.Certainty = 0.99m;
                result.Type = TargetEntityType.Receipt;
            } 
            else if (containsYourReceipt)
            {
                result.Certainty = 0.80m;
                result.Type = TargetEntityType.Receipt;
            }
            else if (containsReceipt)
            {
                result.Certainty = 0.7m;
                result.Type = TargetEntityType.Receipt;
            }

            return result;
        }

    }
}
