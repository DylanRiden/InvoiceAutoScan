using InvoiceAutoScan.Source.Core.Data.SourceConnections;
using InvoiceAutoScan.Source.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Data
{
    public sealed class CommonSourceDataContext: DbContext
    {
        public CommonSourceDataContext(DbContextOptions<CommonSourceDataContext> options) : base(options) { }

        #region DB-Sets

        public DbSet<SourceConnection> Connections { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SourceConnections");
            modelBuilder.ApplyConfiguration(new SourceConnectionConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
