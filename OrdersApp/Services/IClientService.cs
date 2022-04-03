using OrdersApp.Models;

namespace OrdersApp.Services
{
    public interface IClientService
    {
        List<Client> Get();
        Client Get(string id);
        Client Create(Client client);
        void Update(string id, Client client);
        void Delete(string id);
    }
}
