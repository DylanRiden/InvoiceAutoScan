using InvoiceAutoScan.Common.Abstractions.Detection;
using InvoiceAutoScan.Core.Contracts.TargetEntities;
using InvoiceAutoScan.DetectionEngine.Contracts;
using InvoiceAutoScan.DetectionEngine.Core.Detections.Models;
using MassTransit;
using MassTransit.Testing.Implementations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.DetectionEngine.Core.Consumers
{
    public class DetectItemConsumer : IConsumer<DetectItemMessage>
    {
        private readonly ILogger<DetectItemConsumer> logger;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly DetectionEngine detectionEngine;

        public DetectItemConsumer(ILogger<DetectItemConsumer> logger,
            IPublishEndpoint publishEndpoint,
            DetectionEngine detectionEngine)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
            this.detectionEngine = detectionEngine;
        }

        public async Task Consume(ConsumeContext<DetectItemMessage> context)
        {
            IDetectableItem item = context.Message.Item;

            DetectionResult result = detectionEngine.DetectItem(item);

            if (result.Certainty >= 0.5m)
            {
                logger.LogInformation($"DETECTED ITEM: Certainty {(int)result.Certainty * 100}%");

                CreateTargetEntity targetEntity = new()
                {
                    Description = item.Detail,
                    Identifier = item.Identifier,
                    SourceSystemId = item.SourceSystemId,
                    ItemId = item.Id,
                    Type = result.Type,
                    Certainty = result.Certainty
                };

                await publishEndpoint.Publish(targetEntity);
            }
            else
                logger.LogInformation($"POTENTIAL ITEM WITH LOW CERTAINTY: Certainty {(int)result.Certainty * 100}%");
        }
    }
}
