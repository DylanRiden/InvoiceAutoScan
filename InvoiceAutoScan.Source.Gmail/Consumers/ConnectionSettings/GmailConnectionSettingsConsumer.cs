using InvoiceAutoScan.Common.Abstractions.ConnectionSettings;
using InvoiceAutoScan.Source.Gmail.Contracts.ConnectionSettings;
using MassTransit;

namespace InvoiceAutoScan.Source.Gmail.Consumers.ConnectionSettings;

public class GmailConnectionSettingsConsumer : IConsumer<GetGmailConnectionSettings>
{
    public async Task Consume(ConsumeContext<GetGmailConnectionSettings> context)
    {
        GmailConnectionSettings connectionSettings = GmailConnectionSettingsParser.Parse(context.Message.ConnectionSettings);
        GmailConnectionSettingsResult connectionSettingsResponse = new() { RefreshToken = connectionSettings.RefreshToken };
        ConnectionSettingsResult result = ConnectionSettingsResult.FromConnectionSettings(connectionSettingsResponse);
        await context.RespondAsync(result);
    }
}
