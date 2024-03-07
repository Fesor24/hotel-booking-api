using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HB.Domain.Primitives;
[BsonIgnoreExtraElements]
public abstract class Entity
{
    [BsonId]
    //[BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
}
