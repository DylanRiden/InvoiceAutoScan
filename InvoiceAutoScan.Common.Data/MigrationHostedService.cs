using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvoiceAutoScan.Common.Data
{
    public sealed class MigrationHostedService<T>: IHostedService
        where T : DbContext
    {
        private readonly T dataContext;

        public MigrationHostedService(IServiceScopeFactory scopeFactory)
        {
            this.dataContext = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<T>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            await this.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task MigrateAsync()
        {
            await dataContext.Database.MigrateAsync();
        }


    }
}
