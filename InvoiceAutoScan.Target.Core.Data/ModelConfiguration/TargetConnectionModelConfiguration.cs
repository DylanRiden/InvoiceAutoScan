using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Target.Core.Data.TargetConnections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Target.Core.Data.ModelConfiguration
{
    public class TargetConnectionModelConfiguration : IEntityTypeConfiguration<TargetConnection>
    {
        public void Configure(EntityTypeBuilder<TargetConnection> builder)
        {
            builder.ConfigureId();

            builder.Property(x => x.ConnectionSettingsJson)
                .HasColumnType("jsonb");
        }
    }
}
