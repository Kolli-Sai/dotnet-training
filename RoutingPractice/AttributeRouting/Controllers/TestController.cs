using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttributeRouting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]   // GET /api/Test
        public IActionResult ListProducts()
        {
            return Ok("api/Test");
        }

        [HttpGet("{id}")]   // GET /api/Test/xyz
        public IActionResult GetProduct(string id)
        {
            return Ok($"api/Test/{id}");
        }

        [HttpGet("int/{id:int}")] // GET /api/Test/int/3
        public IActionResult GetIntProduct(int id)
        {
            return Ok($"api/Test/int/{id}");
        }

        [HttpGet("int2/{id}")]  // GET /api/Test/int2/3
        public IActionResult GetInt2Product(int id)
        {
            return Ok($"api/Test/in2/{id}");
        }

        [HttpGet("/products3")]
        public IActionResult ListProducts2()
        {
            return Ok($"GET api/Test/products3  ");
        }

        [HttpPost("/products3")]
        public IActionResult CreateProduct(string productName)
        {
            return Ok($"POST api/Test/products3  ");
        }
    }
}
