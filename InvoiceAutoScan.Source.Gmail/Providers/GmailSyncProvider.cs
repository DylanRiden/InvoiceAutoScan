using InvoiceAutoScan.Source.Common;
using InvoiceAutoScan.Source.Common.Contracts;
using InvoiceAutoScan.Source.Gmail.Contracts.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Providers
{
    public sealed class GmailSyncProvider : BaseSourceSyncTriggerProvider
    {
        public override BaseSourceSyncTrigger GetTriggerMessage(Guid sourceId)
        {
            return new GmailSyncTrigger() { SourceSystemId = sourceId };
        }
    }
}
