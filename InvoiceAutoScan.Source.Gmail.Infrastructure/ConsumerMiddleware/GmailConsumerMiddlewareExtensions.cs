using InvoiceAutoScan.Gmail.Common.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Infrastructure.ConsumerMiddleware
{
    public static class GmailConsumerMiddlewareExtensions
    {
        public static IConsumePipeConfigurator AddGmailConsumerMiddleware(this IConsumePipeConfigurator pipeConfigurator, IRegistrationContext context, IServiceCollection services)
        {
            pipeConfigurator.UseConsumeFilter(typeof(GmailClientSetupMiddleware<>), context);
            return pipeConfigurator;
        }
    }
}
