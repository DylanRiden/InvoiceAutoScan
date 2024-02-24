namespace InvoiceAutoScan.Source.Gmail.Contracts
{
    public interface IGmailTaskMessage
    {
        public Guid SourceSystemId { get; }
    }
}