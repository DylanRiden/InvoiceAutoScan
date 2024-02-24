using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Core.Data.Repositories;
using InvoiceAutoScan.Core.SourceSystems.Consumers;
using InvoiceAutoScan.Core.SourceSystems.Data;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Infrastructure.Business.SourceSystems
{
    public static class SourceSystemServiceExtensions
    {
        internal static IServiceCollection AddSourceSystemServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddScoped<ISourceSystemsDataRepository, SourceSystemsDataRepository>();
            busConfigurator.AddSourceConsumers();
            return services;
        }

        private static IBusRegistrationConfigurator AddSourceConsumers(this IBusRegistrationConfigurator configurator)
        {
            configurator.AddConsumer<CreateSourceSystemConsumer>();
            configurator.AddConsumer<SourceSystemRequestConsumer>();
            return configurator;
        }
    }
}
