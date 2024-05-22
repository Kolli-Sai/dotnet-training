using Authentication.Models;

namespace Authentication.Contracts
{
    public interface IUserService
    {
        Task<string> Login(User newUser);
    }
}
