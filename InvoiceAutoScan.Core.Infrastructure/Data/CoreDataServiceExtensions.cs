using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Core.Data;
using InvoiceAutoScan.Core.Data.Repositories.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.CodeDom;


namespace InvoiceAutoScan.Core.Infrastructure.Data
{
    public static class CoreDataServiceExtensions
    {

        internal static IServiceCollection AddCoreDataServices(this IServiceCollection services, IConfiguration configuration)
            => services.AddHostedService<MigrationHostedService<CoreDataContext>>()
                .AddCoreDataContext(configuration)
                .AddGenericDataRepository(configuration);
        
        private static IServiceCollection AddCoreDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDataContext>(options =>
                options.ConfigureIasDatabaseOptions(configuration));
            return services;
        }

        private static IServiceCollection AddGenericDataRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IDataRepository<>), typeof(GenericCoreDataRepository<>));
            return services;
        }

    }
}
