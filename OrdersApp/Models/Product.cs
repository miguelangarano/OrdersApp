using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace OrdersApp.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }
    }
}
