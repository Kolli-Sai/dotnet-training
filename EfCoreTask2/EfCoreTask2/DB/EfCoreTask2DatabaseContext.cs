using EfCoreTask2.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask2.DB
{
    public class EfCoreTask2DatabaseContext:DbContext
    {
        public EfCoreTask2DatabaseContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerProduct> CustomerProducts { get; set; }
    }
}
