using ClientServices.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        public ClientController()
        {
        }

        [HttpGet("{clientId}")]
        public IActionResult GetClient([FromRoute] int clientId)
        {
            var clientDetail = new ClientDto { ClientId = clientId, ClientName = "Example Client", CurrencySymbol = "$" };
            return Ok(clientDetail);
        }
    }
}
