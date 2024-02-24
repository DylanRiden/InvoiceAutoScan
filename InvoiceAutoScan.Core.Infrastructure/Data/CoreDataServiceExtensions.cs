using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Core.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InvoiceAutoScan.Core.Infrastructure.Data
{
    public static class CoreDataServiceExtensions
    {

        internal static IServiceCollection AddCoreDataServices(this IServiceCollection services, IConfiguration configuration)
            => services.AddHostedService<MigrationHostedService<CoreDataContext>>()
                .AddCoreDataContext(configuration);
        
        private static IServiceCollection AddCoreDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDataContext>(options =>
                options.ConfigureIasDatabaseOptions(configuration));
            return services;
        }

    }
}
