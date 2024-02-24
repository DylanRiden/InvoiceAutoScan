using Microsoft.EntityFrameworkCore;
using InvoiceAutoScan.Common.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceAutoScan.Source.Core.Data.SourceConnections;

namespace InvoiceAutoScan.Source.Data.ModelConfiguration
{
    internal class SourceConnectionConfiguration : IEntityTypeConfiguration<SourceConnection>
    {
        public void Configure(EntityTypeBuilder<SourceConnection> builder)
        {
            builder.ConfigureId();

            builder.Property(x => x.ConnectionSettingsJson)
                .HasColumnType("jsonb");
        }
    }
}
