using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Contracts.Sync.ProcessBatchMessage
{
    public record ProcessMessageInfo
    {
        public string MessageId { get; init; }
    }
}
