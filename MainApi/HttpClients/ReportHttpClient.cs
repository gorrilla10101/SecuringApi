using ReportServices.Dtos;

namespace MainApi.HttpClients;

public class ReportHttpClient(HttpClient client)
{
    private const string _reportEndpoint = "/Report";
    public async Task<ReportResultDto?> GenerateReport(ReportDto reportDto)
    {
        var response = await client.PostAsJsonAsync(_reportEndpoint, reportDto);
        response.EnsureSuccessStatusCode();
        var report = await response.Content.ReadFromJsonAsync<ReportResultDto>();
        return report;
    }
}
