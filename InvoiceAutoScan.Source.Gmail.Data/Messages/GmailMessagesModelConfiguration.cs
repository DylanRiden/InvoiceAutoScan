using InvoiceAutoScan.Common.Data;
using InvoiceAutoScan.Source.Gmail.Models.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InvoiceAutoScan.Source.Gmail.Data.Messages
{
    public class GmailMessagesModelConfiguration : IEntityTypeConfiguration<ImportedMessage>
    {
        public void Configure(EntityTypeBuilder<ImportedMessage> builder)
        {
            builder.ConfigureId();
            builder.DefaultSourceIdConfiguration<ImportedMessage, string>();
        }
    }
}
