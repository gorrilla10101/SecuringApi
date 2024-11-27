using ClientServices.Dtos;
using ReportServices.Dtos;

namespace MainApi.Services
{
    public interface IReportService
    {
        Task<ReportResultDto?> GenerateReport(ClientDto client, string reportName);
        Task<ReportSettingsDto?> GetReportSettings(int clientId);
    }
}