using EfCore_Task1.DB;
using EfCore_Task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCore_Task1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly EFCoreTask1DBContext _dbContext;

        public CustomerController(EFCoreTask1DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _dbContext.Customers.ToList();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Customers.Add(newCustomer);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newCustomer.Id }, newCustomer);
        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        {
            if (id != updatedCustomer.Id)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var existingCustomer = _dbContext.Customers.Find(id);
            if (existingCustomer == null)
            {
                return NotFound("Customer not found.");
            }

            existingCustomer.Name = updatedCustomer.Name;
           

            _dbContext.SaveChanges();

            return Ok("Customer updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

            return Ok("Customer deleted.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            return Ok(customer);
        }
    }
}
