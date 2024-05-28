using Authentication.Core.Entities;

namespace Authentication.Core.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> CreateUserAsync(User user);
}
