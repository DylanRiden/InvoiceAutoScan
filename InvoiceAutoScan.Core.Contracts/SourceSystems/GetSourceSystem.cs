namespace InvoiceAutoScan.Core.Contracts.SourceSystems;

public record GetSourceSystem
{
    public Guid SourceSystemId { get; init; }
}
