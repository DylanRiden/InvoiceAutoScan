using InvoiceAutoScan.Source.Common.Contracts;

namespace InvoiceAutoScan.Source.Common;

public abstract class BaseSourceSyncTriggerProvider
{
    public SourceConnectionType ConnectionType { get; }

    public abstract BaseSourceSyncTrigger GetTriggerMessage(Guid sourceId);
}