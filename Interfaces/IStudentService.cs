using Poc.MongoDB.Api.Models;

namespace Poc.MongoDB.Api.Interfaces;

public interface IStudentService
{
    List<Student> Get();
    Student Get(string id);
    Student Create(Student student);
    void Update(string id, Student student);
    void Delete(string id);
}
