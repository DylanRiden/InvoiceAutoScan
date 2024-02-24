using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Source.Core.Data.Connections;
using InvoiceAutoScan.Source.Data;
using InvoiceAutoScan.Source.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Infrastructure.Data
{
    public static class SourceConnectionDataServices
    {
        internal static IServiceCollection AddSourceConnectionCoreDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSourceConnectionDataContext(configuration);
            services.AddHostedService<MigrationHostedService<CommonSourceDataContext>>();
            services.AddSourceConnectionRepositories(configuration);
            return services;
        }

        private static IServiceCollection AddSourceConnectionDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommonSourceDataContext>(options => options.ConfigureIasDatabaseOptions(configuration));
            return services;
        }

        private static IServiceCollection AddSourceConnectionRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISourceConnectionDataRepository, SourceConnectionDataRepository>();
            return services;
        }
    }
}
