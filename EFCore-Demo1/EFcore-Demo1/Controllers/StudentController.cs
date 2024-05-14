using EFcore_Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFcore_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        Efcore1DBContext dbContext;
        public StudentController(Efcore1DBContext efcore1DBContext)
        {
            dbContext = efcore1DBContext;
        }
        [HttpGet]
        public List<Student> Get()
        {
            return dbContext.Students.ToList<Student>();
        }

        [HttpPost]
        public string Post([FromBody] Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return "Student created";
        }

    }
}
