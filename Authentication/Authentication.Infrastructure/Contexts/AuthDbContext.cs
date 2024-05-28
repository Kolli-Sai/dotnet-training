using Authentication.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Contexts;

public class AuthDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public AuthDbContext(DbContextOptions<AuthDbContext> dbContextOptions): base(dbContextOptions)
    {
        
    }
}
