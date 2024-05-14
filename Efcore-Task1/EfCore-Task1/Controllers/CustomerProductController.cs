using EfCore_Task1.DB;
using EfCore_Task1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCore_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly EFCoreTask1DBContext _dbContext;
        public CustomerProductController(EFCoreTask1DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public string Post( [FromBody] CustomerProduct product)
        {
            if (!ModelState.IsValid)
            {
                return "Bad request";
            }
            _dbContext.CustomerProducts.Add(product);
            _dbContext.SaveChanges();

            return "Customer Product added.";


        }

        [HttpGet]
        public List<CustomerProductResponse> Get()
        {
            List<Customer> customers = _dbContext.Customers.ToList();
            List<CustomerProduct> customerProducts = _dbContext.CustomerProducts.ToList();

            List<CustomerProductResponse> customerProductResponses = new List<CustomerProductResponse>();

            foreach (Customer customer in customers)
            {
                CustomerProductResponse customerProductResponse = new CustomerProductResponse()
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    Products = new List<Product>() 
                };

                foreach (CustomerProduct customerProduct in customerProducts)
                {
                    if (customerProduct.CustomerId == customer.Id)
                    {
                        Product product = new Product()
                        {
                            Id = customerProduct.ProductId,
                            Name = customerProduct.Name,
                            Price = customerProduct.Price
                        };

                        customerProductResponse.Products.Add(product);
                    }
                }

                customerProductResponses.Add(customerProductResponse);
            }

            return customerProductResponses;
        }

    }
}
