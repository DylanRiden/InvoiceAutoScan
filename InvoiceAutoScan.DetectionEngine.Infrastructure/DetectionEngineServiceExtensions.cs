using InvoiceAutoScan.DetectionEngine.Contracts;
using InvoiceAutoScan.DetectionEngine.Core.Consumers;
using InvoiceAutoScan.DetectionEngine.Core.Detections;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace InvoiceAutoScan.DetectionEngine.Infrastructure
{
    public static class DetectionEngineServiceExtensions
    {
        public static IServiceCollection AddDetectionEngine(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddDetectionEngineConsumers(configuration, busConfigurator);
            services.AddDetectionEngineServices(configuration);
            return services;
        }

        internal static IServiceCollection AddDetectionEngineServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Core.DetectionEngine>();
            services.AddScoped<InvoiceDetector>();
            services.AddScoped<ReceiptDetector>();
            services.AddScoped<OrderDetector>();
            return services;
        }

        internal static IServiceCollection AddDetectionEngineConsumers(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            busConfigurator.AddConsumer<DetectItemConsumer>();
            return services;
        }
    }
}
