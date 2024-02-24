using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Contracts.Messages
{
    public record ImportedMessageResult: IGmailTaskMessage
    {
        public Guid Id { get; init; }
        
        public Guid SourceSystemId { get; init; }

        public string SourceId { get; init; }

        public string Subject { get; init; }

        public ulong HistoryId { get; init; }

        public DateTime InternalDate { get; init; }
    }
}
