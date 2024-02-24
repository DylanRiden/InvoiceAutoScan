using InvoiceAutoScan.Common.Accessors;

namespace InvoiceAutoScan.Common.Base.Models
{
    public abstract class BaseModel : IIDAccessor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
