using System.Net;
using ClientServices.Dtos;
using MainApi.Dtos;
using MainApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController(ILogger<SettingsController> logger) : ControllerBase
    {
        [HttpGet("GetAllSettings")]
        public async Task<IActionResult> Get([FromServices] IClientService clientService, [FromServices] IReportService reportService, [FromQuery] int clientId)
        {
            if (clientId <= 0)
            {
                return Problem("Client Id must be greater than 0", statusCode: (int)HttpStatusCode.BadRequest);
            }
            try
            {
                var clientSettingsTask = clientService.GetClient(clientId);
                var reportSettingsTask = reportService.GetReportSettings(clientId);

                await Task.WhenAll(clientSettingsTask, reportSettingsTask);
                var clientSettings = clientSettingsTask.Result;
                if (clientSettings is null)
                {
                    logger.LogError("Client settings is null for client {clientId}", clientId);
                    return Problem("Missing Client Settings");
                }

                var reportSettings = reportSettingsTask.Result;
                if (clientSettings is null)
                {
                    logger.LogError("Report settings is null for client {clientId}", clientId);
                    return Problem("Missing Report Settings");
                }

                var settings = new AllClientSettingsDto
                {
                    ClientSettings = clientSettings,
                    ReportSettings = reportSettings
                };
                return Ok(settings);
            }
            catch (AggregateException ex)
            {
                logger.LogError(ex, "One or more tasks failed retrieving settings for client {clientId}", clientId);
                return Problem("Unable to get settings");
            }
        }
    }
}
