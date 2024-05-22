using LINQ_Demo1.Contracts;
using LINQ_Demo1.Data;
using LINQ_Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Demo1.Services
{
    public class LinqMethodsServices : ILinqMethodsServices
    {
        private readonly LINQDbContext _dbContext;
        public LinqMethodsServices(LINQDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        async  Task<bool> ILinqMethodsServices.AllMethod()
        {
            bool customersAbove20 =await  _dbContext.Customers.AllAsync(c => c.CustomerAge > 20);
            
            return customersAbove20;

        }

        async Task<bool> ILinqMethodsServices.AnyMethod()
        {
            bool customerAbove20 = await _dbContext.Customers.AnyAsync(c=>c.CustomerAge>20);
            return customerAbove20;
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.AppendMethod()
        {
            Customer customer = new Customer()
            {
               CustomerName = "user6",
               CustomerAge = 20,
            };

            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            customers.Append(customer);
            return customers;
        }

        async Task<double> ILinqMethodsServices.AverageMethod()
        {
            double average =await _dbContext.Orders.AverageAsync(o=>o.OrderAmount);
            return average;
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.ConcatMethod()
        {
            IEnumerable<Customer> customersAbove20 = await _dbContext.Customers.Where(c=>c.CustomerAge > 20).ToListAsync();
            IEnumerable<Customer> customersBelow20 = await _dbContext.Customers.Where(c=>c.CustomerAge < 20).ToListAsync();
            customersAbove20.Concat(customersBelow20);
            return customersAbove20;
        }

        async Task<bool> ILinqMethodsServices.ContainsMethod()
        {
            Customer customer = new Customer()
            { CustomerId =6,
                CustomerName = "user6",
                CustomerAge = 20,
                
            };
            bool customerWithAge20 = await _dbContext.Customers.ContainsAsync(customer);
            return customerWithAge20;
        }

        async Task<int> ILinqMethodsServices.CountMethod()
        {
            int countOfCustomers = await _dbContext.Customers.CountAsync();
            return countOfCustomers;
        }

        //async Task<IEnumerable<Customer>> ILinqMethodsServices.DefaultIfEmptyMethod()
        //{
        //    Customer defaultCustomer = new Customer()
        //    {
        //        CustomerId = 0,
        //        CustomerAge= 20,
        //        CustomerName="sai"
                
        //    };
        //    IEnumerable<Customer> customers = _dbContext.Customers.Where(c => c.CustomerAge == 50).DefaultIfEmpty(defaultCustomer);

        //    return customers;
        //}

        async Task<Customer> ILinqMethodsServices.ElementAtMethod()
        {
            
           Customer customer = await _dbContext.Customers.ElementAtAsync(0);
            return customer;
        }

        async Task<Customer> ILinqMethodsServices.ElementAtOrDefaultMethod()
        {
            Customer customer = await _dbContext.Customers.ElementAtOrDefaultAsync(0);
            return customer;
        }

        async Task<Customer> ILinqMethodsServices.FirstMethod()
        {
            Customer customer = await _dbContext.Customers.FirstAsync();
            return customer;
        }

        async Task<Customer> ILinqMethodsServices.FirstOrDefaultMethod()
        {
            Customer customer = await _dbContext.Customers.FirstOrDefaultAsync();
            return customer;
        }

        public async Task<IEnumerable<CustomerOrderTotalDto>> GroupByMethod()
        {
            var customers = await _dbContext.Customers
                                            .Include(c => c.Orders)
                                            .ToListAsync();

            var groupedCustomers = customers.GroupBy(c => c.CustomerId)
                                            .Select(g => new CustomerOrderTotalDto
                                            {
                                                CustomerId = g.Key,
                                                CustomerName = g.First().CustomerName,
                                                TotalOrderAmount = g.SelectMany(c => c.Orders).Sum(o => o.OrderAmount)
                                            }).ToList();

            return groupedCustomers;
        }



        async Task<IEnumerable<CustomerOrderDetailDto>> ILinqMethodsServices.JoinMethod()
        {
            var customerOrderDetails = await _dbContext.Customers
                                               .Join(
                                                   _dbContext.Orders,
                                                   customer => customer.CustomerId,
                                                   order => order.CustomerId,
                                                   (customer, order) => new CustomerOrderDetailDto
                                                   {
                                                       CustomerId = customer.CustomerId,
                                                       CustomerName = customer.CustomerName,
                                                       OrderId = order.OrderId,
                                                       ProductName = order.ProductName,
                                                       OrderAmount = order.OrderAmount
                                                   }
                                               ).ToListAsync();

            return customerOrderDetails;
        }

        //async Task<Customer> ILinqMethodsServices.LastMethod()
        //{
        //    Customer customer = await _dbContext.Customers.LastAsync();
        //    return customer;
        //}

        //async Task<Customer> ILinqMethodsServices.LastOrDefaultMethod()
        //{
        //    Customer customer = await _dbContext.Customers.LastOrDefaultAsync();
        //    return customer;
        //}

        async Task<int> ILinqMethodsServices.MaxByMethod()
        {
            int maxAmount = await _dbContext.Orders.MaxAsync(key => key.OrderAmount);
            return maxAmount;
        }

       

        async Task<int> ILinqMethodsServices.MinByMethod()
        {
            int minAmount = await _dbContext.Orders.MinAsync(key => key.OrderAmount);
            return minAmount;
        }

        

      

        async Task<IEnumerable<Customer>> ILinqMethodsServices.OrderByDescendingMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.OrderByDescending(c => c.CustomerAge).ToListAsync();
            return customers;
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.OrderByMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.OrderBy(c=>c.CustomerAge).ToListAsync();
            return customers;
        }

       

        async Task<IEnumerable<Customer>> ILinqMethodsServices.PrependMethod()
        {
            Customer customer = new Customer()
            {
                CustomerId = 0,
                CustomerAge = 20,
                CustomerName = "sai"

            };
            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            customers.Prepend(customer);
            return customers;
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.ReverseMethod()
        {
           IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            return customers.Reverse();
        }

        async Task<IEnumerable<Order>> ILinqMethodsServices.SelectManyMethod()
        {
            IEnumerable<Order> orders = await _dbContext.Customers.SelectMany(c => c.Orders).ToListAsync();
            return orders;
        }

        async Task<IEnumerable<CustomerDTO>> ILinqMethodsServices.SelectMethod()
        {
            IEnumerable<CustomerDTO> customers = await _dbContext.Customers.Select(c => new CustomerDTO()
            {
                CustomerId=c.CustomerId,
                CustomerName=c.CustomerName,
            }).ToListAsync();
            return customers;
            
        }

       

        async Task<IEnumerable<Customer>> ILinqMethodsServices.SkipLastMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            return customers.SkipLast(2);
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.SkipMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            return customers.Skip(2);
        }

       

        async Task<int> ILinqMethodsServices.SumMethod()
        {
            int sum = await _dbContext.Orders.SumAsync(o=>o.OrderAmount);
            return sum;
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.TakeLastMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            return customers.TakeLast(2);
        }

        async Task<IEnumerable<Customer>> ILinqMethodsServices.TakeMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            return customers.Take(2);
        }


      

        async Task<IEnumerable<Customer>> ILinqMethodsServices.ToListMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.ToListAsync();
            return customers.Take(2);
        }

       

        async Task<IEnumerable<Customer>> ILinqMethodsServices.WhereMethod()
        {
            IEnumerable<Customer> customers = await _dbContext.Customers.Where(c=>c.CustomerAge>20).ToListAsync();
            return customers;
        }
    }
}
