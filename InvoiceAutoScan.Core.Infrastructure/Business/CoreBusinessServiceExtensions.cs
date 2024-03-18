using InvoiceAutoScan.Core.Infrastructure.Business.Generic;
using InvoiceAutoScan.Core.Infrastructure.Business.SourceSystems;
using InvoiceAutoScan.Core.Infrastructure.Business.TargetEntities;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InvoiceAutoScan.Core.Infrastructure.Business
{
    public static class CoreBusinessServiceExtensions
    {
        internal static IServiceCollection AddCoreBusinessServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddGenericGetConsumers(configuration, busConfigurator);
            services.AddSourceSystemServices(configuration, busConfigurator);
            services.AddTargetEntityServices(configuration, busConfigurator);
            return services;
        }
    }
}
