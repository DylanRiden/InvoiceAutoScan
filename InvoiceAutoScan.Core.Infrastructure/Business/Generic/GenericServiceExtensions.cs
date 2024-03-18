using Google.Apis.Http;
using InvoiceAutoScan.Common.Base.Models;
using InvoiceAutoScan.Core.Generic.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Core.Infrastructure.Business.Generic;

public static class GenericServiceExtensions
{
    public static IServiceCollection AddGenericGetConsumers(this IServiceCollection services, IConfiguration configuration, IBusRegistrationConfigurator configurator)
    {
        IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(e => e.FullName!.Contains(".Core"));

        IEnumerable<Type> entityTypes = assemblies.SelectMany(e => e.GetExportedTypes())
            .Where(e => e.IsAssignableTo(typeof(BaseModel)) && e.GetType() != typeof(BaseModel));
        
        foreach(var entityType in entityTypes)
        {
            Type getType = CreateGenericGetConsumer(entityType);
            Type listType = CreateGenericListConsumer(entityType);
            configurator.AddConsumer(getType);
            configurator.AddConsumer(listType);
        }

        return services;
    }

    private static Type CreateGenericGetConsumer(Type entityType)
    {
        Type genericType = typeof(GenericGetConsumer<>);

        Type specificType = genericType.MakeGenericType(entityType);

        return specificType;
    }

    private static Type CreateGenericListConsumer(Type entityType)
    {
        Type genericType = typeof(GenericGetListConsumer<>);

        Type specificType = genericType.MakeGenericType(entityType);

        return specificType;
    }
}