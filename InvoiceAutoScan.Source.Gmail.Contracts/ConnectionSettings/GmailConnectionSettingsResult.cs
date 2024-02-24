using InvoiceAutoScan.Common.Abstractions.ConnectionSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Contracts.ConnectionSettings
{
    public record GmailConnectionSettingsResult
    {
        public string RefreshToken { get; init; }
    }
}
