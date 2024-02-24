using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Target.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Target.Core.Data.TargetConnections
{
    public class TargetConnection: BaseModel
    {
        public Guid TargetSystemId { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }

        public TargetConnectionType Type { get; set; }

        public string? ConnectionSettingsJson { get; set; }
    }
}
