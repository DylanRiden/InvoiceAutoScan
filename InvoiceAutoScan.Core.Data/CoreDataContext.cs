using InvoiceAutoScan.Core.Data.ModelConfiguration;
using InvoiceAutoScan.Core.SourceSystems;
using InvoiceAutoScan.Core.TargetEntities;
using InvoiceAutoScan.Core.TargetSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InvoiceAutoScan.Core.Data
{
    public class CoreDataContext : DbContext
    {
        public CoreDataContext(DbContextOptions<CoreDataContext> options) : base(options)
        {
        }

        public DbSet<SourceSystem> SourceSystems { get; set; }

        public DbSet<TargetSystem> TargetSystems { get; set; }

        public DbSet<TargetEntity> TargetEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Core");
            modelBuilder.ApplyConfiguration(new SourceSystemsModelConfiguration());
            modelBuilder.ApplyConfiguration(new TargetSystemsModelConfiguration());
            modelBuilder.ApplyConfiguration(new TargetEntitiesModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
