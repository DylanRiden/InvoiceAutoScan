using InvoiceAutoScan.Common.Abstractions.ConnectionSettings;
using InvoiceAutoScan.Core.Contracts.SourceSystems;
using InvoiceAutoScan.Source.Core.Contracts.Connections.ConnectionSettings;
using InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection;
using InvoiceAutoScan.Source.Core.Data.Connections;
using InvoiceAutoScan.Source.Core.Data.SourceConnections;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Consumers.SourceConnections
{
    public sealed class CreateSourceConnectionConsumer : IConsumer<CreateSourceConnection>
    {
        private readonly IRequestClient<ConnectionSettingsRequest> connectionSettingsRequestClient;
        private readonly IRequestClient<GetSourceSystem> sourceSystemRequestClient;
        private readonly ISourceConnectionDataRepository dataRepository;

        public CreateSourceConnectionConsumer(IRequestClient<ConnectionSettingsRequest> connectionSettingsRequestClient,
            IRequestClient<GetSourceSystem> sourceSystemRequest, ISourceConnectionDataRepository dataRepository)
        {
            this.connectionSettingsRequestClient = connectionSettingsRequestClient;
            sourceSystemRequestClient = sourceSystemRequest;
            this.dataRepository = dataRepository;
        }

        public async Task Consume(ConsumeContext<CreateSourceConnection> context)
        {
            GetSourceSystem sourceSystemRequest = new()
            {
                SourceSystemId = context.Message.SourceSystemId
            };

            Response<SourceSystemResult, SourceSystemNotFound> sourceSystemResponse = await sourceSystemRequestClient.GetResponse<SourceSystemResult, SourceSystemNotFound>(sourceSystemRequest);
            object sourceSystem = sourceSystemResponse.Message;

            if (sourceSystem is SourceSystemNotFound)
            {
                await context.RespondAsync(sourceSystem);
                return;
            }

            ConnectionSettingsRequest settingsRequest = new()
            {
                SourceConnectionType = context.Message.ConnectionType,
                ConnectionSettings = context.Message.ConnectionSettings
            };

            Response<ConnectionSettingsResult> connectionSettingsResult = await connectionSettingsRequestClient.GetResponse<ConnectionSettingsResult>(settingsRequest);

            string json = JsonSerializer.Serialize(connectionSettingsResult.Message.ConnectionSettings);

            SourceConnection connection = new()
            {
                ConnectionSettingsJson = json,
                ConnectionType = context.Message.ConnectionType,
                CreatedDate = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                ModifiedDate = DateTime.UtcNow,
                SourceId = context.Message.SourceSystemId
            };

            SourceConnectionResult result = new()
            {
                Id = connection.Id,
                SourceId = connection.SourceId,
            };

            await dataRepository.CreateAsync(connection);

            await context.RespondAsync(result);
        }
    }
}
