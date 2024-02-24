using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Tests.Connections
{
    public static class ConnectionSettingsTestData
    {
        public static IDictionary<string, object> GetCorrectData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            data.Add("EmailAddress", "dylan@gmail.com");

            data.Add("Password", "password123");

            return data;
        }

        public static IDictionary<string, object> GetIncorrectEmailData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            data.Add("EmailAddress", "dylan");

            data.Add("Password", "password123");

            return data;
        }

        public static IDictionary<string, object> GetEmptyData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            return data;
        }


    }
}
