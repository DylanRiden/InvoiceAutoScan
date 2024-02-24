using InvoiceAutoScan.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Abstractions.ConnectionSettings
{
    public class ConnectionSettingsResult
    {
        public ConnectionSettingsResult()
        {
        }

        public IDictionary<string, object> ConnectionSettings { get; set; }
        
        public static ConnectionSettingsResult FromConnectionSettings(object connectionSettings)
        {
            return new ConnectionSettingsResult() { ConnectionSettings = ObjectHelper.ToDictionary(connectionSettings)};
        }



    }
}
