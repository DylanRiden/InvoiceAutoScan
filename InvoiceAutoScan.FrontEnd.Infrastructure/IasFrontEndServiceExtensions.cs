using InvoiceAutoScan.FrontEnd.ApiClient.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceAutoScan.FrontEnd.Infrastructure;

public static class IasFrontEndServiceExtensions
{
    public static IServiceCollection AddIasFrontEndServices(this IServiceCollection services, IConfiguration configuration)
    {
        String? dirtyEnvironmentName = configuration.GetRequiredSection("EnvName").Value;
        
        if(string.IsNullOrWhiteSpace(dirtyEnvironmentName))
            throw new InvalidOperationException("EnvName Configuration Variable Must Not Be Null");

        IasFrontEndEnvNames environmentName = Enum.Parse<IasFrontEndEnvNames>(dirtyEnvironmentName);

        switch (environmentName)
        {
            case IasFrontEndEnvNames.LocalDev:
            case IasFrontEndEnvNames.Dev:
                services.AddIasApiSerivces(configuration);
                break;

            case IasFrontEndEnvNames.Faker:
            default:
                
                break;
        }

        return services;
    }


}
