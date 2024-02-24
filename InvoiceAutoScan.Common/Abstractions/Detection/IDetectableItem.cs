namespace InvoiceAutoScan.Common.Abstractions.Detection
{
    public interface IDetectableItem
    {
        public Guid Id { get; }

        public string Detail { get; }

        public bool HasFile { get; }

        public string Identifier { get; }

        public Guid SourceSystemId { get; }
    }
}
