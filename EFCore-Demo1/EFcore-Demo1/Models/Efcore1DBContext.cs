using Microsoft.EntityFrameworkCore;
namespace EFcore_Demo1.Models
{
    public class Efcore1DBContext:DbContext
    {
        public Efcore1DBContext(DbContextOptions<Efcore1DBContext> contextOptions):base(contextOptions)
        {
           
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
