using EfCoreTask2.DB;
using EfCoreTask2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EfCoreTask2DatabaseContext _dbContext;
        public CustomerController(EfCoreTask2DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            List<Customer> customers = await _dbContext.Customers.ToListAsync<Customer>();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            if (_dbContext.Customers == null)
            {
                return NotFound();
            }

            Customer customerFound = await _dbContext.Customers.FindAsync(id);
            if (customerFound == null)
            {
                return NotFound();
            }
            return Ok(customerFound);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            CreatedAtActionResult createdAtActionResult = CreatedAtAction(
                            actionName: nameof(GetCustomerById),
                            routeValues: new { id = customer.CustomerId },
                            value: customer
                            );
            return createdAtActionResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, Customer customer)
        {
            if(id != customer.CustomerId)
            {
                return BadRequest();
            }
            Customer customerFound = await _dbContext.Customers.FindAsync(id);
            if (customerFound == null)
            {
                return NotFound();
            }

            customerFound.CustomerName = customer.CustomerName;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            Customer customerFound = await _dbContext.Customers.FindAsync(id);
            if (customerFound == null)
            {
                return NotFound();
            }
            _dbContext.Customers.Remove(customerFound);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }



    }
}
