using InvoiceAutoScan.Source.Gmail.Consumers.Sync;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.Business.Sync
{
    internal static class GmailSyncServiceExtensions
    {
        internal static IServiceCollection AddGmailSyncServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            busConfigurator.AddConsumer<GmailSyncConsumer>();
            busConfigurator.AddConsumer<GmailProcessMessageConsumer>();
            busConfigurator.AddConsumer<GmailProcessBatchMessageConsumer>();
            return services;
        }
    }
}
