using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Source.Gmail.Data;
using InvoiceAutoScan.Source.Gmail.Data.Messages;
using InvoiceAutoScan.Source.Gmail.Models.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.Data
{
    public static class GmailDataExtensions
    {

        internal static IServiceCollection AddGmailDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGmailDataContext(configuration);
            services.AddDataRepositories(configuration);
            return services;
        }

        private static IServiceCollection AddDataRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IImportedMessagesRepository, ImportedMessagesDataRepository>();
            return services;
        }

        private static IServiceCollection AddGmailDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GmailSourceDataContext>(options => options.ConfigureIasDatabaseOptions(configuration));
            return services;
        }


    }
}
