using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Entities;
using Authentication.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _dbContext;
        public UserRepository(AuthDbContext dbContext)
        {
            this._dbContext = dbContext;   
        }

        async Task<bool> IUserRepository.CreateUserAsync(User user)
        {
             _dbContext.Users.Add(user);
            int rowsEffected = await _dbContext.SaveChangesAsync();
            return rowsEffected>0;
        }

         async Task<User> IUserRepository.GetUserByEmailAsync(string email)
        {
            var user = await _dbContext.Users.Where(u=>u.Email==email).FirstOrDefaultAsync();
            return user;
        }
    }
}
