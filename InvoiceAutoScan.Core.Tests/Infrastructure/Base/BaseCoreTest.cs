using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Tests.Infrastructure.Base
{
    public abstract class BaseCoreTest
    {
        public BaseCoreTest()
        {

        }

        public abstract Task Setup();
    }
}
