using CRUD_Web_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentOperations operations;

        public StudentController(IStudentOperations operations)
        {
            this.operations = operations;
        }

        [HttpPost("/student")]
        public void CreateStudent([FromBody] Student newStudent)
        {
           operations.CreateStudent(newStudent);
        }

        [HttpGet("/student/{id}")]
        public Student GetStudent(int id)
        {
           return operations.GetStudent(id);
        }

        [HttpGet("/students")]
        public List<Student> GetStudents()
        {
            return operations.GetStudents();
        }

        [HttpDelete("/student/{id}")]
        public void DeleteStudent(int id)
        {
           operations.DeleteStudent(id);
        }

        [HttpPatch("/student/{id}")]
        public void UpdateStudent([FromBody] Student newStudent,int id)
        {

           operations.UpdateStudent(newStudent,id);
        }
    }
}
