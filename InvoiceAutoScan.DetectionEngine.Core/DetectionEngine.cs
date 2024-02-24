using InvoiceAutoScan.Common.Abstractions.Detection;
using InvoiceAutoScan.DetectionEngine.Core.Detections;
using InvoiceAutoScan.DetectionEngine.Core.Detections.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.DetectionEngine.Core
{
    public class DetectionEngine
    {
        private readonly ILogger<DetectionEngine> logger;
        private readonly InvoiceDetector invoiceDetector;
        private readonly ReceiptDetector receiptDetector;
        private readonly OrderDetector orderDetector;

        public DetectionEngine(ILogger<DetectionEngine> logger,
            InvoiceDetector invoiceDetector,
            ReceiptDetector receiptDetector,
            OrderDetector orderDetector)
        {
            this.logger = logger;
            this.invoiceDetector = invoiceDetector;
            this.receiptDetector = receiptDetector;
            this.orderDetector = orderDetector;
        }

        public DetectionResult DetectItem(IDetectableItem item)
        {
            List<DetectionResult> results = 
                [
                    invoiceDetector.DetectInvoice(item),
                    receiptDetector.DetectReceipt(item),
                    orderDetector.DetectOrder(item)
                ];

            return results.Where(e => e is not null).OrderByDescending(e => e.Certainty).First();
        }
    }
}
