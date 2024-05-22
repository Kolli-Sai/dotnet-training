using EfCore_Task1.Models;
using Microsoft.EntityFrameworkCore;
namespace EfCore_Task1.DB
{
    public class EFCoreTask1DBContext:DbContext
    {
        public EFCoreTask1DBContext(DbContextOptions<EFCoreTask1DBContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }

    }
}
