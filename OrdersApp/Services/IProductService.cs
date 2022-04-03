using OrdersApp.Models;

namespace OrdersApp.Services
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(string id);
        Product Create(Product product);
        void Update(string id, Product product);
        void Delete(string id);
    }
}
