using InvoiceAutoScan.Common.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Base.Models
{
    public class BaseImportedItemModel<TSourceId> : BaseModel, IIDAccessor, ISourceIDAccessor<TSourceId>
    {
        public TSourceId SourceId { get; set; }
    }
}
