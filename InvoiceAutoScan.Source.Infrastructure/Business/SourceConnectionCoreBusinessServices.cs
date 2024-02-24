using InvoiceAutoScan.Source.Core.Consumers.ConnectionSettings;
using InvoiceAutoScan.Source.Core.Consumers.SourceConnections;
using InvoiceAutoScan.Source.Core.Consumers.Sync;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Infrastructure.Business
{
    public static class SourceConnectionCoreBusinessServices
    {
        internal static IServiceCollection AddSourceConnectionCoreBusinessServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            busConfigurator.AddConsumer<ConnectionSettingsRequestConsumer>();
            busConfigurator.AddConsumer<CreateSourceConnectionConsumer>();
            busConfigurator.AddConsumer<RequestSourceConnectionConsumer>();
            busConfigurator.AddConsumer<SourceSyncTriggerConsumer>();
            return services;
        }
    }
}
