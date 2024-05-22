using DTOsPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DTOsPractice.DataBase
{
    public class DTOPracticeDatabaseContext:DbContext
    {
        public DTOPracticeDatabaseContext(DbContextOptions<DTOPracticeDatabaseContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
