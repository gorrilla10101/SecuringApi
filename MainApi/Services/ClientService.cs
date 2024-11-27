using ClientServices.Dtos;
using MainApi.HttpClients;

namespace MainApi.Services
{
    public class ClientService(ClientHttpClient httpClient) : IClientService
    {
        public Task<ClientDto?> GetClient(int clientId)
        {
            return httpClient.GetClient(clientId);
        }

        public Task<ClientSettingsDto?> GetClientSettings(int clientId)
        {
            return httpClient.GetClientSettings(clientId);
        }
    }
}
