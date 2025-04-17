using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace astronautas.entity;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }

    [BsonIgnore]
    public User? User { get; set; }
}
