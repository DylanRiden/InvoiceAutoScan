using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Data
{
    public static class CommonDatabaseServiceExtensions
    {
        public static DbContextOptionsBuilder ConfigureIasDatabaseOptions(this DbContextOptionsBuilder options, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");

            if (connectionString is null)
                throw new NullDatabaseConfigurationException();

            options.UseNpgsql(connectionString, opt => {});

            return options;
        } 
    }
}
