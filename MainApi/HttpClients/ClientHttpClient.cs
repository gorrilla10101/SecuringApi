namespace MainApi.HttpClients;
public class ClientHttpClient(HttpClient client)
{
    public Task GetClient(int clientId)
    {

        return Task.CompletedTask;

    }
}
