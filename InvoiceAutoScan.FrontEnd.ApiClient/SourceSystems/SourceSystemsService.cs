using InvoiceAutoScan.Core.Contracts.Base;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Create;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Update;
using InvoiceAutoScan.FrontEnd.Abstractions;
using InvoiceAutoScan.FrontEnd.ApiClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.FrontEnd.ApiClient.SourceSystems
{
    internal class SourceSystemsService : ISourceSystemsService
    {
        private readonly IASApiService apiService;

        public SourceSystemsService(IASApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<IasResponse<SourceSystemResult>> Create(CreateSourceSystem value)
        {
            throw new NotImplementedException();
        }

        public async Task<IasResponse> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IasResponse<SourceSystemResult>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IasListResponse<SourceSystemResult>> List(Func<IQueryable<SourceSystemResult>, IQueryable<SourceSystemResult>> query)
        {
            HttpResponseMessage response = await this.apiService.client.GetAsync("SourceSystems");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<IasListResponse<SourceSystemResult>>())!;
        }

        public async Task<IasResponse<SourceSystemResult>> Update(UpdateSourceSystem value)
        {
            throw new NotImplementedException();
        }
    }
}
