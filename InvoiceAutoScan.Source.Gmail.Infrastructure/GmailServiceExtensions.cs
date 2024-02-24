using InvoiceAutoScan.Common.Source.Options;
using InvoiceAutoScan.Source.Gmail.Infrastructure.Business;
using InvoiceAutoScan.Source.Gmail.Infrastructure.Data;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure
{
    public static class GmailServiceExtensions
    {
        public static IServiceCollection AddGmailSourceServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            services.AddGmailDataServices(configuration);
            services.AddGmailBusinessServices(configuration, busConfigurator);
            services.AddGmailSecrets(configuration);
            return services;
        }

        public static IServiceCollection AddGmailSecrets(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleCredentials>(options => 
            {
                options.ClientId = configuration["Google:ClientId"];
                options.ClientSecret = configuration["Google:ClientSecret"];
            });

            return services;
        }

    }
}
