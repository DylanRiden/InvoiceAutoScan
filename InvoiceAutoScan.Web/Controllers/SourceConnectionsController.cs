using InvoiceAutoScan.Source.Core.Contracts.Connections.SourceConnection;
using InvoiceAutoScan.Source.Core.Contracts.Connections.Trigger;
using MassTransit;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using static Google.Apis.Auth.OAuth2.Web.AuthorizationCodeWebApp;
using Microsoft.AspNetCore.Authentication;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2.Responses;
using MassTransit.Configuration;
using InvoiceAutoScan.Common.Source.Options;
using Microsoft.Extensions.Options;
using static MassTransit.ValidationResultExtensions;
using InvoiceAutoScan.Core.Contracts.SourceSystems.Result;

namespace InvoiceAutoScan.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceConnectionsController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IRequestClient<CreateSourceConnection> connectionRequestClient;

        public SourceConnectionsController(IPublishEndpoint publishEndpoint,
            IRequestClient<CreateSourceConnection> connectionRequestClient)
        {
            this.publishEndpoint = publishEndpoint;
            this.connectionRequestClient = connectionRequestClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSourceConnection([FromBody] CreateSourceConnection createConnection)
        {
            if (createConnection.ConnectionType == Source.Common.SourceConnectionType.Gmail)
                return BadRequest("Use Gmail Specific Endpoint");

            Response<SourceConnectionResult, SourceSystemNotFound> result = await this.connectionRequestClient.GetResponse<SourceConnectionResult, SourceSystemNotFound>(createConnection);

            if(result.Message is SourceSystemNotFound)
                return BadRequest(result.Message);
            
            return Ok(result.Message);
        }

        [HttpPost("{sourceId}/sync")]
        public async Task<IActionResult> StartSync([FromRoute] Guid sourceId)
        {
            TriggerSourceSync syncMessage = new() { SourceId = sourceId };
            await this.publishEndpoint.Publish(syncMessage);
            return Ok();
        }

        [GoogleScopedAuthorize(GmailService.ScopeConstants.GmailReadonly)]
        [HttpGet ("google/{sourceSystemId}")]
        public async Task<IActionResult> CreateGmailSourceConnection([FromServices]IGoogleAuthProvider auth,  [FromRoute]Guid sourceSystemId)
        {
            CreateSourceConnection createConnection = new() { SourceSystemId = sourceSystemId };

            if (createConnection.ConnectionType != Source.Common.SourceConnectionType.Gmail)
                return BadRequest("Use General Connection Endpoint");

            //if not empty

            GoogleCredential cred = await auth.GetCredentialAsync();

            AuthenticateResult auth2 = await HttpContext.AuthenticateAsync();
            string? refreshToken = auth2.Properties?.GetTokenValue(OpenIdConnectParameterNames.RefreshToken);

            if (refreshToken is null)
                return Unauthorized();

            createConnection.ConnectionSettings = new Dictionary<string, object>();

            createConnection.ConnectionSettings["RefreshToken"] = refreshToken;

            Response<SourceConnectionResult, SourceSystemNotFound> result = await this.connectionRequestClient.GetResponse<SourceConnectionResult, SourceSystemNotFound>(createConnection);

            if (result.Message is SourceSystemNotFound)
                return BadRequest(result.Message);

            //Response.Cookies.Delete();

            return Ok();
        }
    }
}
