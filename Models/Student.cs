using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poc.MongoDB.Api.Models;

[BsonIgnoreExtraElements]
public class Student
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("isgraduated")]
    public bool IsGraduated { get; set; }

    [BsonElement("courses")]
    public List<string>? Courses { get; set; }

    [BsonElement("gender")]
    public string Gender { get; set; } = string.Empty;

    [BsonElement("age")]
    public int Age { get; set; }
}
