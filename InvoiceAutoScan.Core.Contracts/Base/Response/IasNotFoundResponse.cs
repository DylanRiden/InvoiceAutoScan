using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.Base.Response
{
    public record IasNotFoundResponse
    {
        public string Status => "Not Found";
        public int ResponseCode => 404;
    }
}
