namespace MainApi.HttpClients;

public class ReportHttpClient(HttpClient client)
{
    public Task GenerateReport(int clientId)
    {
        return Task.CompletedTask;
    }
}
