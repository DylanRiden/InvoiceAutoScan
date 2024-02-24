using System.Runtime.Serialization;

namespace InvoiceAutoScan.Common.Data
{
    [Serializable]
    internal class NullDatabaseConfigurationException : Exception
    {
        public NullDatabaseConfigurationException() : base("Database connection string was null.") { }
    }
}