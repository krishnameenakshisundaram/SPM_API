using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SPM_API.Options;
using SPM_API.Services;

namespace SPM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkStationConfigurationController : ControllerBase
    {
        #region Private Variables and Properties

        private ICosmosService _cosmosService;

        private readonly ILogger<WorkStationConfigurationController> _logger;

        public CosmosCredentials? Credentials { get; }

        #endregion Private Variables and Properties


        public WorkStationConfigurationController(ICosmosService cosmosService, ILogger<WorkStationConfigurationController> logger, IOptions<CosmosCredentials> credentialOptions)
        {
            _cosmosService = cosmosService;
            _logger = logger;
            Credentials = credentialOptions.Value;
        }

        [HttpGet]
        [Route("GetAllWorkStationConfig")]
        public async Task<IActionResult> GetAllWorkStationConfig()
        {
            if (Credentials is not null)
                if (!String.IsNullOrEmpty(Credentials.Endpoint) && !String.IsNullOrEmpty(Credentials.Key))
                {
                    var workStationConfigDetails = await _cosmosService.RetrieveAllWorkStationConfigAsync();                    
                    return Ok(workStationConfigDetails);
                }
            return BadRequest();
            
        }
    }
}