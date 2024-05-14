using Microsoft.AspNetCore.Mvc;
using BillingSystem.Models;
namespace BillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerRequest req)
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id,UpdateCustomerRequest req)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok();
        }
    }
}
