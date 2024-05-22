using BillingSystemApi.DataBase;
using BillingSystemApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly BillinSystemApiWithEfCore _dbContext;
        public InvoiceController(BillinSystemApiWithEfCore dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> Get()
        {
            var invoices = await _dbContext.Customers
                .Include(c => c.Transactions)
                .SelectMany(c => c.Transactions.Select(t => new Invoice
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    TransactionId = t.TransactionId,
                    TransactionFor = t.TransactionFor,
                    TransactionsAmount = t.TransactionsAmount,
                    IsTransactionSuccessfull = t.IsTransactionSuccessfull,
                    TransactionDateTime = t.TransactionDateTime
                }))
                .ToListAsync();

            return invoices;
        }

        [HttpGet("{transactionId}")]
        public async Task<ActionResult<Invoice>> GetById(int transactionId)
        {
            if (_dbContext.Transactions ==null)
            {
                return NotFound();
            }
            Transaction transaction = await _dbContext.Transactions.FindAsync(transactionId);
            if(transaction == null)
            {
                return NotFound();
            }

            Customer customer = await _dbContext.Customers.FindAsync(transaction.CustomerId);
            if(customer == null)
            {
                return NotFound();
            }

            Invoice invoice = new Invoice()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                TransactionId = transaction.TransactionId,
                TransactionFor = transaction.TransactionFor,
                TransactionsAmount = transaction.TransactionsAmount,
                IsTransactionSuccessfull = transaction.IsTransactionSuccessfull,
                TransactionDateTime = transaction.TransactionDateTime
            };
            return Ok(invoice);
        }

        [HttpGet("{customerId}/{transactionId}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int customerId, int transactionId)
        {
            
            var customer = await _dbContext.Customers
                .Include(c => c.Transactions)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound(); 
            }

            var transaction = customer.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);

            if (transaction == null)
            {
                return NotFound(); 
            }

            var invoice = new Invoice
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                TransactionId = transaction.TransactionId,
                TransactionFor = transaction.TransactionFor,
                TransactionsAmount = transaction.TransactionsAmount,
                IsTransactionSuccessfull = transaction.IsTransactionSuccessfull,
                TransactionDateTime = transaction.TransactionDateTime
            };

            return invoice;
        }


    }
}
