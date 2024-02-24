using InvoiceAutoScan.Target.Core.Data.ModelConfiguration;
using InvoiceAutoScan.Target.Core.Data.TargetConnections;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAutoScan.Target.Core.Data
{
    public class CommonTargetDataContext : DbContext
    {
        public CommonTargetDataContext(DbContextOptions<CommonTargetDataContext> options) : base(options) { }
            
        #region DB-Sets

        public DbSet<TargetConnection> TargetConnections { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TargetConnections");
            modelBuilder.ApplyConfiguration(new TargetConnectionModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

