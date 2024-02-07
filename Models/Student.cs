using MongoDB.Bson.Serialization.Attributes;

namespace Poc.MongoDB.Api.Models;

[BsonIgnoreExtraElements]
public class Student
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsGraduated { get; set; }
    public List<string>? Courses { get; set; }
    public string Gender { get; set; } = string.Empty;
    public int Age { get; set; }
}
