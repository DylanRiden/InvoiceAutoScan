namespace InvoiceAutoScan.Common.Accessors.Items
{
    public interface IItemDatesAccessor
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
