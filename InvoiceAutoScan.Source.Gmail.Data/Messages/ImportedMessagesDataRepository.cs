using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Common.Data.Repository;
using InvoiceAutoScan.Source.Gmail.Models.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Data.Messages
{
    public class ImportedMessagesDataRepository : BaseImportedItemDataRepository<ImportedMessage, string>, IImportedMessagesRepository
    {
        private readonly GmailSourceDataContext dbContext;

        public ImportedMessagesDataRepository(GmailSourceDataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override DbSet<ImportedMessage> GetDbSet() 
            => dbContext.ImportedMessages;

    }
}