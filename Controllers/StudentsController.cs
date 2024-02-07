using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc.MongoDB.Api.Interfaces;
using Poc.MongoDB.Api.Models;

namespace Poc.MongoDB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return _studentService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);

            if (student != null) return student;

            return NotFound($"Student with Id = {id} not found");
        }

        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            _studentService.Create(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, Student student)
        {
            var existingStudent = _studentService.Get(id);

            if(existingStudent == null) return NotFound($"Student with Id = {id} not found");

            _studentService.Update(id, student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = _studentService.Get(id);

            if (student == null) return NotFound($"Student with Id = {id} not found");

            _studentService.Delete(student.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
