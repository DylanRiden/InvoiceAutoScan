using InvoiceAutoScan.Common.Abstractions.Detection;
using InvoiceAutoScan.Common.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Models.Messages
{
    public class ImportedMessage : BaseImportedItemModel<string>, IDetectableItem
    {
        public string Subject { get; set; }

        public DateTime InternalDate { get; set; }

        public ulong HistoryId { get; set; }

        public string From { get; set; }

        //DetectableItem Implementation

        public string Detail => Subject;

        //TODO
        public bool HasFile {get => false; set => _ = value;}

        public string Identifier => SourceId;

        public Guid SourceSystemId { get; set; }
    }
}
