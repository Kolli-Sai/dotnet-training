using BillingSystemApi.DataBase;
using BillingSystemApi.DTOs;
using BillingSystemApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly BillinSystemApiWithEfCore _dbContext;

        public TransactionController(BillinSystemApiWithEfCore dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            List<Transaction> transactions = await _dbContext.Transactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(CreateTransactionRequest request)
        {
            Customer customerFound = await _dbContext.Customers.FindAsync(request.CustomerId);
            if (customerFound == null)
            {
                return BadRequest("Customer doesn't exist, First create a customer.");
            }

            Transaction newTransaction = new Transaction
            {
                CustomerId = customerFound.CustomerId,
               
                IsTransactionSuccessfull = request.IsTransactionSuccessfull,
                TransactionDateTime = request.TransactionDateTime,
                TransactionFor = request.TransactionFor,
                TransactionsAmount = request.TransactionsAmount,
                
            };

            _dbContext.Transactions.Add(newTransaction);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransactionById), new { id = newTransaction.TransactionId }, newTransaction);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaction(int id, UpdateTransactionRequest transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest("Transaction ID mismatch");
            }

            var existingTransaction = await _dbContext.Transactions.FindAsync(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            Customer customerFound = await _dbContext.Customers.FindAsync(transaction.CustomerId);
            if (customerFound == null)
            {
                return BadRequest("CustomerId is Invalid.");
            }

            _dbContext.Entry(existingTransaction).CurrentValues.SetValues(transaction);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Transactions.Any(e => e.TransactionId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _dbContext.Transactions.Remove(transaction);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
