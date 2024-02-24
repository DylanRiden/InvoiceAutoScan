namespace InvoiceAutoScan.Source.Common.Contracts;

public record BaseSourceSyncTrigger
{
    public Guid SourceSystemId { get; init; }
}
