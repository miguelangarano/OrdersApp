using OrdersApp.Models;
using MongoDB.Driver;

namespace OrdersApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientService(IOrdersStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientsCollectionName);
        }

        public Client Create(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Delete(string id)
        {
            _clients.DeleteOne(product => product.Id == id);
        }

        public List<Client> Get()
        {
            return _clients.Find(client => true).ToList();
        }

        public Client Get(string id)
        {
            return _clients.Find(client => client.Id == id).FirstOrDefault();
        }

        public void Update(string id, Client client)
        {
            _clients.ReplaceOne(client => client.Id == id, client); ;
        }
    }
}
