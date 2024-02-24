using InvoiceAutoScan.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Consumers.ConnectionSettings
{
    public static class GmailConnectionSettingsParser
    {
        public static GmailConnectionSettings Parse(IDictionary<string, object> data)
        {
            data.TryGetValue("RefreshToken", out object refreshObj);

            if(refreshObj is null)
                throw new KeyNotFoundException("Refresh token not found in data dictionary");

            if(refreshObj is not string refreshToken)
                throw new InvalidTypeException(refreshObj.GetType(), typeof(string));
            
            GmailConnectionSettings settings = new GmailConnectionSettings(refreshToken);

            return settings;
        }
    }
}
