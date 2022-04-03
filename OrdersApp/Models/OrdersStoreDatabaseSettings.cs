namespace OrdersApp.Models
{
    public class OrdersStoreDatabaseSettings : IOrdersStoreDatabaseSettings
    {
        public string OrdersCollectionName { get; set; } = String.Empty;
        public string ProductsCollectionName { get; set; } = String.Empty;
        public string ClientsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
