using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceAutoScan.FrontEnd.Faker
{
    public static class IasFakerClientServicesExtensions
    {

        public static IServiceCollection AddIasFakerServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

    }
}
