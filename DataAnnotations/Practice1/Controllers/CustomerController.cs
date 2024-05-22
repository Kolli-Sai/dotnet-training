using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get( Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x=>x.ErrorMessage).ToList();
                return Ok(new { Errors = errors });
            }
            return Ok("Hello");
        }
    }
}
