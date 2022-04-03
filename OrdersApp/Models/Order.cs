using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace OrdersApp.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("client")]
        public Client Client { get; set; }

        [BsonElement("products")]
        public List<Product> Products { get; set; }

        [BsonElement("date")]
        public int Date { get; set; }
    }
}
