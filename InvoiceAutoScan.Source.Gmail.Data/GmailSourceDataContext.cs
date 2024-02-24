using InvoiceAutoScan.Source.Data;
using InvoiceAutoScan.Source.Gmail.Data.Messages;
using InvoiceAutoScan.Source.Gmail.Models.Messages;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAutoScan.Source.Gmail.Data
{
    public class GmailSourceDataContext : DbContext
    {

        public DbSet<ImportedMessage> ImportedMessages { get; set; }

        public GmailSourceDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Sources.Gmail");
            modelBuilder.ApplyConfiguration(new GmailMessagesModelConfiguration());
        }

    }
}
