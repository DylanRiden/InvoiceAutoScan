using InvoiceAutoScan.Source.Gmail.Infrastructure.ConsumerMiddleware;
using MassTransit;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Infrastructure.Messaging
{
    public static class ConsumeMiddlewareServices
    {
        public static IConsumePipeConfigurator AddConsumerMiddleware(this IConsumePipeConfigurator pipeConfigurator, IRegistrationContext context, IServiceCollection services)
        {
            pipeConfigurator.AddSourcesConsumerMiddleware(context, services);
            return pipeConfigurator;
        }

        private static IConsumePipeConfigurator AddSourcesConsumerMiddleware(this IConsumePipeConfigurator pipeConfigurator, IRegistrationContext context, IServiceCollection services)
        {
            pipeConfigurator.AddGmailConsumerMiddleware(context, services);
            return pipeConfigurator;
        }

    }
}
