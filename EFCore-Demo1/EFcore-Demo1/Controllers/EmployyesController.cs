using EFcore_Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFcore_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployyesController : ControllerBase
    {
        Efcore1DBContext db;
        public EmployyesController(Efcore1DBContext efcore1DBContext)
        {
            db = efcore1DBContext;
        }
        [HttpGet]
        public List<Employee> Get()
        {
            return db.Employees.ToList<Employee>();
        }

        [HttpPost]
        public string Post([FromBody] Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return "Employee created";
        }
    }
}
