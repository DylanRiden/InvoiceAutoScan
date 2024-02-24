using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Core.TargetEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Data.ModelConfiguration
{
    internal sealed class TargetEntitiesModelConfiguration : IEntityTypeConfiguration<TargetEntity>
    {
        public void Configure(EntityTypeBuilder<TargetEntity> builder)
        {
            builder.ConfigureId();

            //Not required, however we will enforce the requirement on
            //the consumer level.
            //This is so that if the source system is forcefully deleted by the user
            //we will still keep the entities created by it.
            builder.HasOne(e => e.SourceSystem)
                .WithMany()
                .HasForeignKey(e => e.SourceSystemId)
                .IsRequired(false);

            builder.Property(e => e.ItemId).IsRequired(true);
        }
    }
}
