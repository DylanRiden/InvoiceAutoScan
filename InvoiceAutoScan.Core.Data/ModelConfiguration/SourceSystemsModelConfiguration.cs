using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Core.SourceSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Data.ModelConfiguration
{
    internal class SourceSystemsModelConfiguration : IEntityTypeConfiguration<SourceSystem>
    {
        public void Configure(EntityTypeBuilder<SourceSystem> builder)
        {
            builder.ConfigureId();
        }
    }
}
