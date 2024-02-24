namespace InvoiceAutoScan.Target.Dext.Contracts
{
    public record GetDextConnectionSettings
    {
        public IDictionary<string, object> ConnectionSettings { get; init; }
    }
}
