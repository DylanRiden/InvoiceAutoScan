using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace InvoiceAutoScan.Gateway.Auth.Google
{
    public static class GoogleAuthenticationConfigurator
    {
        public static IServiceCollection ConfigureGoogleAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string cid = configuration.GetValue<string>("Google:ClientID");
            string csec = configuration.GetValue<string>("Google:ClientSecret");


            services
                .AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogleOpenIdConnect(options =>
            {
                options.ClientId = cid;
                options.ClientSecret = csec;
            });
            return services;
        }
        
    }
}
