using InvoiceAutoScan.Core.Generic.Consumers;
using InvoiceAutoScan.Core.Infrastructure.Business;
using InvoiceAutoScan.Core.Infrastructure.Business.SourceSystems;
using InvoiceAutoScan.Core.Infrastructure.Data;
using InvoiceAutoScan.Core.Infrastructure.Messaging;
using InvoiceAutoScan.DetectionEngine.Infrastructure;
using InvoiceAutoScan.Source.Infrastructure;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceAutoScan.Core.Infrastructure
{
    public static class CoreServiceExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCoreDataServices(configuration);

            services.AddMassTransit(messagingConfigurator =>
            {

                services.AddCoreBusinessServices(configuration, messagingConfigurator);
                services.AddSourceConnectionServices(configuration, messagingConfigurator);

                services.AddDetectionEngine(configuration, messagingConfigurator);

                messagingConfigurator.UsingRabbitMq((context, rabbitMqConfigurator) =>
                {
                    rabbitMqConfigurator.Host("localhost", "/", h => 
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    rabbitMqConfigurator.AddConsumerMiddleware(context, services);

                    rabbitMqConfigurator.ConfigureEndpoints(context);
                });
            });
            
            return services;
        }
    }
}
