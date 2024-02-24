using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using InvoiceAutoScan.Source.Common;
using InvoiceAutoScan.Source.Gmail.Infrastructure.Business.ConnectionSettings;
using InvoiceAutoScan.Source.Gmail.Infrastructure.Business.Messages;
using InvoiceAutoScan.Source.Gmail.Infrastructure.Business.Sync;
using InvoiceAutoScan.Source.Gmail.Providers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.Business
{
    public static class GmailBusinessServiceExtensions
    {
        internal static IServiceCollection AddGmailBusinessServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddGmailProviders(configuration);
            services.AddScoped<GmailApiContext>();
            services.AddGmailConnectionSettingsServices(configuration, busConfigurator);
            services.AddGmailSyncServices(configuration, busConfigurator);
            services.AddGmailMessagesServices(configuration, busConfigurator);
            return services;
        }

        internal static IServiceCollection AddGmailProviders(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BaseSourceSyncTriggerProvider, GmailSyncProvider>();
            return services;    
        }
    }
}
