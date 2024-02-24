using InvoiceAutoScan.Core.Data.Repositories;
using InvoiceAutoScan.Core.TargetEntities.Consumers;
using InvoiceAutoScan.Core.TargetEntities.Data;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Infrastructure.Business.TargetEntities
{
    public static class TargetEntityServiceExtensions
    {
        public static IServiceCollection AddTargetEntityServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator configurator)
        {
            services.AddTargetEntityPersistenceServices();
            configurator.AddTargetEntityConsumers();
            return services;
        }

        private static IServiceCollection AddTargetEntityPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ITargetEntityDataRepository, TargetEntitiesDataRepository>();
            return services;
        }

        private static IBusRegistrationConfigurator AddTargetEntityConsumers(this IBusRegistrationConfigurator configurator)
        {
            configurator.AddConsumer<CreateTargetEntityConsumer>();
            return configurator;
        }
    }
}
