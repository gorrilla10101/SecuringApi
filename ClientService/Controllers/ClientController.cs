using Microsoft.AspNetCore.Mvc;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetClient()
        {
            var clientDetail = new ClientDetails { ClientId = 1, ClientName = "Example Client" };
            return Ok(clientDetail);
        }
    }
}
