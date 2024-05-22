using EfCoreTask2.DB;
using EfCoreTask2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly EfCoreTask2DatabaseContext _dbContext;
        public CustomerProductController(EfCoreTask2DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerProduct>>> Get()
        {
            List<CustomerProduct> customerProducts = await _dbContext.CustomerProducts.ToListAsync();
            return Ok(customerProducts);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            List<Customer> customers = await _dbContext.Customers.ToListAsync();
            List<Product> products = await _dbContext.Products.ToListAsync();
            List<CustomerProduct> customerProducts = await _dbContext.CustomerProducts.ToListAsync();

            List<CustomerProductResponse> result = new List<CustomerProductResponse>();

            foreach (Customer customer in customers)
            {
                CustomerProductResponse productResponse = new CustomerProductResponse();
                productResponse.CustomerId = customer.CustomerId;
                productResponse.CustomerName = customer.CustomerName;
                productResponse.Products = new List<Product>();

                foreach (CustomerProduct  cp in customerProducts)
                {
                    if(cp.CustomerId == customer.CustomerId)
                    {
                        foreach(Product product in products)
                        {
                            if(cp.ProductId == product.ProductId)
                            {
                                productResponse.Products.Add(product);
                            }
                        }
                    }
                }
                result.Add(productResponse);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Post(CustomerProduct customerProduct)
        {
            Customer customer = await _dbContext.Customers.FindAsync(customerProduct.CustomerId);
            if (customer == null)
            {
                return BadRequest();
            }

            Product product = await _dbContext.Products.FindAsync(customerProduct.ProductId);
            if (product == null)
            {
                return BadRequest();
            }

            CustomerProduct obj = new CustomerProduct()
            {
                CustomerId = customerProduct.CustomerId,
                ProductId = product.ProductId,
            };

            _dbContext.CustomerProducts.Add(obj);
            await _dbContext.SaveChangesAsync();
            return Ok("Created");
        }

    }
}
