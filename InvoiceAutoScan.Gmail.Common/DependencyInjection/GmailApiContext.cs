using Google.Apis.Gmail.v1;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Gmail.Common.DependencyInjection
{
    public class GmailApiContext
    {
        public GmailService GmailService { get; set; }

        public SourceSystemResult SourceSystem { get; set; }
        
        public string UserID { get; set; }

    }
}
