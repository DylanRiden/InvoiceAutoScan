using InvoiceAutoScan.Source.Gmail.Consumers.ConnectionSettings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.Business.ConnectionSettings
{
    public static class GmailConnectionSettingsServices
    {
        internal static IServiceCollection AddGmailConnectionSettingsServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            busConfigurator.AddConsumer<GmailConnectionSettingsConsumer>();
            return services;
        }
    }
}
