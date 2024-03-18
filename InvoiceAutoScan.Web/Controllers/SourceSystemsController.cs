using InvoiceAutoScan.Core.Contracts.Base;
using InvoiceAutoScan.Core.Contracts.Base.Request;
using InvoiceAutoScan.Core.Contracts.Base.Response;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Create;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Get;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;
using InvoiceAutoScan.Core.SourceSystems;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAutoScan.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceSystemsController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IRequestClient<CreateSourceSystem> createRequestClient;
        private readonly IRequestClient<GenericGetRequest<SourceSystem>> getRequestClient;
        private readonly IRequestClient<ListSourceSystems> listRequestClient;

        public SourceSystemsController(IPublishEndpoint publishEndpoint,
            IRequestClient<CreateSourceSystem> createRequestClient, 
            IRequestClient<GenericGetRequest<SourceSystem>> getRequestClient,
            IRequestClient<ListSourceSystems> listRequestClient)
        {
            this.publishEndpoint = publishEndpoint;
            this.createRequestClient = createRequestClient;
            this.getRequestClient = getRequestClient;
            this.listRequestClient = listRequestClient;
        }

        [HttpGet("{sourceSystemId}")]
        public async Task<IActionResult> GetSourceSystem([FromRoute]Guid sourceSystemId)
        {
            GenericGetRequest<SourceSystem> request = new() { Id = sourceSystemId };
            var response = await getRequestClient.GetResponse<SourceSystem, IasNotFoundResponse>(request);
            
            object apiResponse;

            if(response.Message is SourceSystem system)
            {
                 apiResponse = new IasResponse<SourceSystem>(system, true);
            }
            else
            {
                apiResponse = ((IasNotFoundResponse)response.Message);
            }

            return Ok(apiResponse);
        }

        [HttpGet()]
        public async Task<IActionResult> GetSourceSystems()
        {
            ListSourceSystems request = new();
            var response = await listRequestClient.GetResponse<ListSourceSystemsResult>(request);
            return Ok(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSourceSystem(CreateSourceSystem createSourceSystem)
        {
            var response = await createRequestClient.GetResponse<SourceSystemResult>(createSourceSystem);
            return Ok(response.Message);
        }
    }
}
