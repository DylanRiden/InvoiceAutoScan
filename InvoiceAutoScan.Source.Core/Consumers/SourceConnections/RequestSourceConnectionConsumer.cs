using InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection;
using InvoiceAutoScan.Source.Core.Data.Connections;
using InvoiceAutoScan.Source.Core.Data.SourceConnections;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InvoiceAutoScan.Source.Core.Consumers.SourceConnections
{
    public class RequestSourceConnectionConsumer : IConsumer<GetSourceConnection>, IConsumer<GetConnectionForSource>
    {
        private readonly ILogger<RequestSourceConnectionConsumer> logger;
        private readonly ISourceConnectionDataRepository dataRepository;

        public RequestSourceConnectionConsumer(ILogger<RequestSourceConnectionConsumer> logger,
            ISourceConnectionDataRepository dataRepository)
        {
            this.logger = logger;
            this.dataRepository = dataRepository;
        }

        public async Task Consume(ConsumeContext<GetSourceConnection> context)
        {
            SourceConnection? connection = await dataRepository.GetAsync(context.Message.SourceConnectionId);
            SourceConnectionResult result = MapToResult(connection);
            await context.RespondAsync(result);
        }

        public async Task Consume(ConsumeContext<GetConnectionForSource> context)
        {
            SourceConnection? connection = dataRepository.Get(q => q.SourceId == context.Message.SourceId);
            SourceConnectionResult result = MapToResult(connection);
            await context.RespondAsync(result);
        }

        private SourceConnectionResult MapToResult(SourceConnection sourceConnection)
        {
            IDictionary<string, object> conncetionSettings = JsonSerializer.Deserialize<Dictionary<string, object>>(sourceConnection.ConnectionSettingsJson);

            return new()
            {
                Id = sourceConnection.Id,
                //ConnectionType = sourceConnection.ConnectionType,
                SourceId = sourceConnection.SourceId,
                ConnectionSettings = conncetionSettings,
                //ConnectionData = sourceConnection.ConnectionData
            };
        }



    }
}
