using ClientServices.Dtos;

namespace MainApi.HttpClients;
public class ClientHttpClient(HttpClient client)
{
    private const string ClientEndpoint = "Client/{0}";
    private const string ClientSettingsEndpoint = "Client/{0}/Settings";
    public Task<ClientDto?> GetClient(int clientId)
    {
        return client.GetFromJsonAsync<ClientDto>(string.Format(ClientEndpoint, clientId));
    }

    internal Task<ClientSettingsDto?> GetClientSettings(int clientId)
    {
        return client.GetFromJsonAsync<ClientSettingsDto>(string.Format(ClientSettingsEndpoint, clientId));
    }
}
