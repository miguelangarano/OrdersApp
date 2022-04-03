namespace OrdersApp.Models
{
    public interface IOrdersStoreDatabaseSettings
    {
        string OrdersCollectionName { get; set; }
        string ProductsCollectionName { get; set; }
        string ClientsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
