using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportServices.Dtos;

namespace ReportService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        [HttpPost]
        [Authorize("CanGenerateReport")]
        public IActionResult CreateClientReport([FromBody] ReportDto reportDto)
        {
            var result = new ReportResultDto
            {
                ClientId = reportDto.ClientId,
                ReportName = reportDto.ReportName,
                ClientName = reportDto.ClientName,
                CurrencySymbol = reportDto.CurrencySymbol,
                IsCompleted = true,
                Total = 1000
            };
            return Ok(result);
        }

        [HttpGet("Settings")]
        [Authorize("CanReadReportSettings")]
        public IActionResult GetReportSettings([FromQuery] int clientId)
        {
            var result = new ReportSettingsDto
            {
                DateTimeFormat = "yyyy-mm-dd"
            };
            return Ok(result);
        }
    }
}
