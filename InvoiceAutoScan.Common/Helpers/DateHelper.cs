using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Helpers
{
    public static class DateHelper
    {
        public static DateTime FromEpoch(long milliseconds)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(milliseconds).ToLocalTime();
            return date;
        }

        public static DateTime FromEpochToUTC(long milliseconds)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(milliseconds).ToUniversalTime();
            return date;
        }
    }
}
