using InvoiceAutoScan.Core.Contracts.SourceSystems;
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
        private readonly IRequestClient<GetSourceSystem> getRequestClient;
        private readonly IRequestClient<ListSourceSystems> listRequestClient;

        public SourceSystemsController(IPublishEndpoint publishEndpoint,
            IRequestClient<CreateSourceSystem> createRequestClient, 
            IRequestClient<GetSourceSystem> getRequestClient,
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
            var response = await getRequestClient.GetResponse<GetSourceSystem, SourceSystemNotFound>(new { SourceSystemId = sourceSystemId });
            return Ok(response.Message);
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
