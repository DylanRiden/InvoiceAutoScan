using InvoiceAutoScan.Core.Contracts.SourceSystems;
using InvoiceAutoScan.Source.Common;
using InvoiceAutoScan.Source.Common.Contracts;
using InvoiceAutoScan.Source.Core.Contracts.Connections.Trigger;
using InvoiceAutoScan.Source.Core.Data.Connections;
using InvoiceAutoScan.Source.Core.Data.SourceConnections;
using InvoiceAutoScan.Source.Gmail.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Consumers.Sync
{
    public class SourceSyncTriggerConsumer : IConsumer<TriggerSourceSync>
    {
        private readonly ISourceConnectionDataRepository dataRepository;
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IEnumerable<BaseSourceSyncTriggerProvider> triggerProviders;

        public SourceSyncTriggerConsumer(ISourceConnectionDataRepository dataRepository, 
            IPublishEndpoint publishEndpoint,
            IEnumerable<BaseSourceSyncTriggerProvider> triggerProviders)
        {
            this.dataRepository = dataRepository;
            this.publishEndpoint = publishEndpoint;
            this.triggerProviders = triggerProviders;
        }

        public async Task Consume(ConsumeContext<TriggerSourceSync> context)
        {
            Guid id = context.Message.SourceId;

            SourceConnection? connection = dataRepository.Get(q => q.SourceId == id);
            //Handle null
            //return null response if non existant, this is a duplicate call but that is ok

            BaseSourceSyncTriggerProvider triggerProvider =
                triggerProviders.Single(e => e.ConnectionType == connection.ConnectionType);

            object trigger = triggerProvider.GetTriggerMessage(id);

            await this.publishEndpoint.Publish(trigger);
        }
    }
}
