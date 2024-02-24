using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Core.TargetSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Data.ModelConfiguration
{
    public class TargetSystemsModelConfiguration : IEntityTypeConfiguration<TargetSystem>
    {
        public void Configure(EntityTypeBuilder<TargetSystem> builder)
        {
            builder.ConfigureId();
        }
    }
}
