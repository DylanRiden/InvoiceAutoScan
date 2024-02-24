using InvoiceAutoScan.Common.Base.DataRepositories;
using InvoiceAutoScan.Source.Core.Data.SourceConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Core.Data.Connections
{
    public interface ISourceConnectionDataRepository: IDataRepository<SourceConnection>
    {
    }
}
