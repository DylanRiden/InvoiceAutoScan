using InvoiceAutoScan.Common.Abstractions.Detection;
using InvoiceAutoScan.DetectionEngine.Core.Detections.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.DetectionEngine.Core.Detections
{
    public class OrderDetector
    {
        private readonly ILogger<OrderDetector> logger;

        public OrderDetector(ILogger<OrderDetector> logger)
        {
            this.logger = logger;
        }

        public DetectionResult DetectOrder(IDetectableItem item)
        {
            //nothing yet, will have to look into this
            return default;
        }
    }
}
