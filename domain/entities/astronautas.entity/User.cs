using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace astronautas.entity;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
