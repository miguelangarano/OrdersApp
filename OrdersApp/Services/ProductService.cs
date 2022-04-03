using OrdersApp.Models;
using MongoDB.Driver;

namespace OrdersApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IOrdersStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Delete(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            return _products.Find(product => product.Id == id).FirstOrDefault();
        }

        public void Update(string id, Product product)
        {
            _products.ReplaceOne(product => product.Id == id, product); ;
        }
    }
}
