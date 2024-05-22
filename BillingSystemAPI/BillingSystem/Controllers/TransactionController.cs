using BillingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTransaction(CreateTransactionRequest req)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id,UpdateTransactionRequest req)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            return Ok();
        }
    }
}
