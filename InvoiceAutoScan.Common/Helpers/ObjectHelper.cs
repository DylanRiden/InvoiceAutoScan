using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Helpers
{
    public static class ObjectHelper
    {
        public static IDictionary<string, object>? ToDictionary(object obj)
        {
            string jsonStr = JsonSerializer.Serialize(obj);
            IDictionary<string, object> data = JsonSerializer.Deserialize<IDictionary<string, object>>(jsonStr);
            return data;
        }
    }
}
