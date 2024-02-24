using InvoiceAutoScan.Source.Gmail.Consumers.ConnectionSettings;
using InvoiceAutoScan.Source.Gmail.Consumers.Messages;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.Business.Messages
{
    internal static class GmailMessagesExtensions
    {
        internal static IServiceCollection AddGmailMessagesServices(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator busConfigurator)
        {
            busConfigurator.AddConsumer<CreateImportedMessageConsumer>();
            busConfigurator.AddConsumer<GetImportedMessageConsumer>();
            return services;
        }
    }
}
