using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class AuthenticationContext:DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
