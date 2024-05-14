using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("/message")]
        public string GetMessage()
        {
            return "Hello world!";
        }
        [HttpGet("/student")]
        public Student GetStudent()
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Student1",
                Age = 22
            };

            return student;
        }

        [HttpGet("/students")]
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student
            {
                Id = 1,
                Name = "Student1",
                Age = 22
            }); students.Add(new Student
            {
                Id = 2,
                Name = "Student2",
                Age = 22
            });

            return students;
        }

       
    }

}
