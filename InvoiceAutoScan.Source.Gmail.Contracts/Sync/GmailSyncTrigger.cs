using InvoiceAutoScan.Source.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Contracts.Sync
{
    public record GmailSyncTrigger: BaseSourceSyncTrigger, IGmailTaskMessage
    {
            
    }
}
