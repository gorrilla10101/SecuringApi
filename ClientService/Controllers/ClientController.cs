using System.Security.Cryptography.X509Certificates;
using ClientServices.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private static int delayCounter = 1;
        public ClientController()
        {
        }

        [Authorize("CanGetClientInfo")]
        [HttpGet("{clientId}")]
        public IActionResult GetClient([FromRoute] int clientId)
        {
            var clientDetail = new ClientDto { ClientId = clientId, ClientName = "Example Client", CurrencySymbol = "$" };
            return Ok(clientDetail);
        }
        [Authorize("CanReadClientSettings")]
        [HttpGet("{clientId}/settings")]
        public async Task<IActionResult> GetClientSettings([FromRoute] int clientId)
        {
            var shouldDelay = (delayCounter % 3) != 0;
            if (shouldDelay)
            {
                await Task.Delay(300);
                delayCounter++;
            }
            else
            {
                delayCounter = 1;
            }
            var settings = new ClientSettingsDto
            {
                ManagesSubClients = false,
                Module1Enabled = true
            };
            return Ok(settings);
        }
    }
}
