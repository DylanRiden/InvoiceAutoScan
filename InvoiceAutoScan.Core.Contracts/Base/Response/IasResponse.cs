using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Contracts.Base
{
    public class IasResponse<T>
        where T : class
    {
        public IasResponse(T obj, bool success)
        {
            this.Value = obj;

            this.Success = success;
            if (success)
                Status = HttpStatusCode.OK;
        }

        public T Value { get; set; }

        public bool Success { get; protected set; }

        public HttpStatusCode Status { get; set; }

    }

    //For JSON
    public class IasResponse
    {
        public object Value { get; set; }

        public bool Success { get; set; }

        public HttpStatusCode Status { get; set; }
    }

}
