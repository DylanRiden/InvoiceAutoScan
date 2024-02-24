namespace InvoiceAutoScan.Source.Gmail
{
    public record GmailConnectionSettings 
    {
        public GmailConnectionSettings(string refreshToken)
        {
            this.RefreshToken = refreshToken;
        }

        public GmailConnectionSettings() { }

        public string RefreshToken { get; init; }
    }
}
