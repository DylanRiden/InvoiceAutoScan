using InvoiceAutoScan.Common.Accessors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAutoScan.Common.Data
{
    public static class BaseModelConfig
    {
        public static void ConfigureId<T>(this EntityTypeBuilder<T> idAccessor)
            where T : class, IIDAccessor
        {
            idAccessor.HasKey(e => e.Id);
        }

        public static void DefaultSourceIdConfiguration<T, TSourceId>(this EntityTypeBuilder<T> idAccessor)
            where T: class, ISourceIDAccessor<TSourceId>
        {
            idAccessor
                .HasIndex(e => e.SourceId)
                .IsUnique();
        }
    }
}
