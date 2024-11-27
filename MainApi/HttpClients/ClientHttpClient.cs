using ClientServices.Dtos;

namespace MainApi.HttpClients;
public class ClientHttpClient(HttpClient client)
{
    private const string ClientEndpoint = "Client/{0}";
    public Task<ClientDto?> GetClient(int clientId)
    {
        return client.GetFromJsonAsync<ClientDto>(string.Format(ClientEndpoint, clientId));
    }
}
