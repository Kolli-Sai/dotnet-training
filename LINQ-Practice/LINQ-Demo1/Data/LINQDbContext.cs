using LINQ_Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Demo1.Data
{
    public class LINQDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public LINQDbContext(DbContextOptions<LINQDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
    }
}
