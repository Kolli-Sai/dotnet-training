using BillingSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingSystemApi.DataBase
{
    public class BillinSystemApiWithEfCore : DbContext
    {
        public BillinSystemApiWithEfCore(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Enable lazy loading proxies
                optionsBuilder.UseLazyLoadingProxies();

            }
        }

    }
}