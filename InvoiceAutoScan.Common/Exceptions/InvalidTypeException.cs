using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Common.Exceptions
{
    public class InvalidTypeException(Type desiredType, Type actualType) :
        Exception($"Invalid Type: Desired Type: {desiredType.ToString()} - Actual Type: {actualType.ToString()}");
}
