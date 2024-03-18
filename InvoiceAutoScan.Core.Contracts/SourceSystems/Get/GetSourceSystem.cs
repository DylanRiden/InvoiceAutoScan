namespace InvoiceAutoScan.Core.Contracts.SourceSystems.Get;

public record GetSourceSystem
{
    public Guid SourceSystemId { get; init; }
}
