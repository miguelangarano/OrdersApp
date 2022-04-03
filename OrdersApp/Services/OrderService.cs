using OrdersApp.Models;
using MongoDB.Driver;

namespace OrdersApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IOrdersStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
        }

        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }

        public void Delete(string id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }

        public List<Order> Get()
        {
            return _orders.Find(order => true).ToList();
        }

        public Order Get(string id)
        {
            return _orders.Find(order => order.Id==id).FirstOrDefault();
        }

        public void Update(string id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order); ;
        }
    }
}
