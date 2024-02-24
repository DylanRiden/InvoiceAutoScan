using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Accessors
{
    public interface ISourceIDAccessor<TID>
    {
        public TID SourceId { get; set; }
    }
}
