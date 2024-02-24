using InvoiceAutoScan.Source.Core.Infrastructure.Business;
using InvoiceAutoScan.Source.Core.Infrastructure.Data;
using InvoiceAutoScan.Source.Gmail.Infrastructure;
using InvoiceAutoScan.Source.Gmail.Infrastructure.Business.ConnectionSettings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceAutoScan.Source.Infrastructure
{
    public static class SourceConnectionInfrastructureExtentions
    {
        public static IServiceCollection AddSourceConnectionServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddCoreSourceConnectionServices(configuration, busConfigurator);
            services.AddAllSources(configuration, busConfigurator);
            return services;
        }

        private static IServiceCollection AddCoreSourceConnectionServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddSourceConnectionCoreDataServices(configuration);
            services.AddSourceConnectionCoreBusinessServices(configuration, busConfigurator);
            return services;
        }

        private static IServiceCollection AddAllSources(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddGmailSourceServices(configuration, busConfigurator);
            return services;
        }
    }
}
