using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.FrontEnd.ApiClient.Infrastructure
{
    public sealed class IASApiService
    {
        public readonly HttpClient client;

        public IASApiService(HttpClient client, IConfiguration configuration)
        {
            IConfigurationSection apiSection = configuration.GetRequiredSection("Api");
            string? baseUrl = apiSection.GetRequiredSection("BaseUrl").Value;

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("Base API URL can't be null");

            Uri baseUri = new(baseUrl);

            client.BaseAddress = baseUri;

            this.client = client;
        }        

    }
}
