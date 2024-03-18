using InvoiceAutoScan.FrontEnd.Abstractions;
using InvoiceAutoScan.FrontEnd.ApiClient.SourceSystems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace InvoiceAutoScan.FrontEnd.ApiClient.Infrastructure;

public static class IasAPIClientServicesExtensions
{

    public static IServiceCollection AddIasApiSerivces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIASHttpServices(configuration);
        return services;
    }

    private static IServiceCollection AddIASHttpServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IASApiService>();
        services.AddScoped<ISourceSystemsService, SourceSystemsService>();
        return services;
    }

}
