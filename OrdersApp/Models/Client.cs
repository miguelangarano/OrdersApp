using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace OrdersApp.Models
{
    [BsonIgnoreExtraElements]
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("phone")]
        public string phone { get; set; }

        [BsonElement("fullname")]
        public string Fullname { get; set; }
    }
}
