using MongoDB.Driver;
using Poc.MongoDB.Api.Interfaces;
using Poc.MongoDB.Api.Models;

namespace Poc.MongoDB.Api.Services;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;

    public StudentService(IDbSchoolDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentCollectionName);
    }
    
    public List<Student> Get()
    {
        return _students.Find(student => true).ToList();
    }

    public Student Get(string id)
    {
        return _students.Find(student => student.Id == id).FirstOrDefault();
    }

    public Student Create(Student student)
    {
        _students.InsertOne(student);
        return student;
    }

    public void Update(string id, Student student)
    {
        _students.ReplaceOne(student => student.Id == id, student);
    }

    public void Delete(string id)
    {
        _students.DeleteOne(student => student.Id == id);
    }
}
