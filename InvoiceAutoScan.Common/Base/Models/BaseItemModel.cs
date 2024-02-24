using InvoiceAutoScan.Common.Accessors.Items;

namespace InvoiceAutoScan.Common.Base.Models
{
    public abstract class BaseItemModel : BaseModel, IItemNameAccessor,  IItemDatesAccessor
    {
        public string DisplayName { get; set; }
        public string SystemName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
