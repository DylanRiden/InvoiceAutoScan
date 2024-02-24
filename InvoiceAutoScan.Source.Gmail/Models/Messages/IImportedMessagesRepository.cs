using InvoiceAutoScan.Common.Base.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Models.Messages
{
    public interface IImportedMessagesRepository: IImportedItemDataRepository<ImportedMessage, string>;
}
