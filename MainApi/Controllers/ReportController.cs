using ClientServices.Dtos;
using MainApi.Dtos;
using MainApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController(ILogger<ReportController> logger) : ControllerBase
    {
        /// <param name="clientService"></param>
        /// <param name="reportService"></param>
        /// <param name="generateReportDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GenerateReport([FromServices] IClientService clientService, [FromServices] IReportService reportService, [FromBody] GenerateReportDto generateReportDto)
        {
            if (generateReportDto.ClientId <= 0)
            {
                return BadRequest("Client Id must be greater than 0");
            }
            ClientDto? client;
            try
            {
                client = await clientService.GetClient(generateReportDto.ClientId);
                if (client == null)
                {
                    return BadRequest("Invalid Client");
                }
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, "Failed to retrieve client details for client {ClientId}", generateReportDto.ClientId);
                return Problem($"Client Service responded with {ex.StatusCode}", statusCode: (int?)ex.StatusCode);
            }

            try
            {
                var report = await reportService.GenerateReport(client, generateReportDto.ReportName);
                return Ok(report);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, "Failed to retrieve report {ReportName} for client {ClientId}", generateReportDto.ReportName, generateReportDto.ClientId);
                return Problem($"Report service responded with {ex.StatusCode}", statusCode: (int?)ex.StatusCode);
            }
        }
    }
}
