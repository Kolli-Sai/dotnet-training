using BillingSystemApi.DataBase;
using BillingSystemApi.DTOs;
using BillingSystemApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BillingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly BillinSystemApiWithEfCore _dbContext;
        public CustomerController(BillinSystemApiWithEfCore dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            try
            {
                List<Customer> customers = await _dbContext.Customers
                    .Include(c => c.Transactions)
                    
                    .ToListAsync();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            if (_dbContext.Customers == null)
            {
                return NotFound();
            }
            Customer existingCustomer = await _dbContext.Customers.FindAsync(id);
            if(existingCustomer == null)
            {
                return NotFound();
            }
            return Ok(existingCustomer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CreateCustomerRequest request)
        {
            Customer newCustomer = new Customer
            {
                CustomerName = request.CustomerName,

            };
            _dbContext.Customers.Add(newCustomer);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(
                actionName:nameof(GetCustomerById),
                routeValues:new {id = newCustomer.CustomerId},
                value: newCustomer
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id,UpdateCustomerRequest request)
        {
            if(id != request.CustomerId)
            {
                return BadRequest();
            }

            if(_dbContext.Customers == null)
            {
                return NotFound();
            }

            Customer existingCustomer = await _dbContext.Customers.FindAsync(id);
            if(existingCustomer == null)
            {
                return NotFound();
            }

            _dbContext.Entry(existingCustomer).CurrentValues.SetValues(request);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return NoContent();


        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            if (_dbContext.Customers == null)
            {
                return NotFound();
            }

            Customer existingCustomer = await _dbContext.Customers.FindAsync(id);
            if(existingCustomer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(existingCustomer);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }
        private bool CustomerExists(int id)
        {
            return (_dbContext.Customers?.Any(e=>e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
