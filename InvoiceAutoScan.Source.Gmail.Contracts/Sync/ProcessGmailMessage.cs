using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Contracts.Sync
{
    public record ProcessGmailMessage : IGmailTaskMessage
    {
        public Guid SourceSystemId { get; init; }

        public string MessageId { get; init; }
    }
}
