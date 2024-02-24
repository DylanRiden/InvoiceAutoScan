using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Helpers
{
    public static class ConnectionSettingsHelper
    {
        public static string ToJsonString(IDictionary<string, object> connectionSettings)
        {
            return JsonSerializer.Serialize(connectionSettings);
        }

        public static object? FromJsonString(string jsonString)
        {
            Type type = typeof(IDictionary<string, object>);
            return JsonSerializer.Deserialize(jsonString, type);
        }
    }
}
