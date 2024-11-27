using ClientServices.Dtos;
using MainApi.HttpClients;
using ReportServices.Dtos;

namespace MainApi.Services
{
    public class ReportService(ReportHttpClient httpClient) : IReportService
    {
        public Task<ReportResultDto?> GenerateReport(ClientDto client, string reportName)
        {
            var reportDto = new ReportDto()
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                CurrencySymbol = client.CurrencySymbol,
                ReportName = reportName
            };
            return httpClient.GenerateReport(reportDto);
        }
    }
}
