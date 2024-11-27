using ClientServices.Dtos;

namespace MainApi.Services
{
    public interface IClientService
    {
        Task<ClientDto?> GetClient(int clientId);
    }
}