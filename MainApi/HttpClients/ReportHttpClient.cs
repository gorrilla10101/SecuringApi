using ReportServices.Dtos;

namespace MainApi.HttpClients;

public class ReportHttpClient(HttpClient client)
{
    private const string _reportEndpoint = "/Report";
    private const string _reportSettingsEndpoint = "/Report/Settings?clientId={0}";
    public async Task<ReportResultDto?> GenerateReport(ReportDto reportDto)
    {
        var response = await client.PostAsJsonAsync(_reportEndpoint, reportDto);
        response.EnsureSuccessStatusCode();
        var report = await response.Content.ReadFromJsonAsync<ReportResultDto>();
        return report;
    }

    public Task<ReportSettingsDto?> GetReportSettings(int clientId)
    {
        var endpoint = string.Format(_reportSettingsEndpoint, clientId);
        return client.GetFromJsonAsync<ReportSettingsDto>(endpoint);
    }
}
