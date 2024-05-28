using Authentication.Core.Entities;

namespace Authentication.Core.Contracts.Services;

public interface IPasswordHelperService
{
    byte[] GenerateSalt(int size = 16);
    byte[] GenerateHash(string password, byte[] salt);
    bool VerifyPassword(string passwordToBeHashed, byte[] salt, byte[] hashedPassword);
    string GenerateToken(User user, string secretKey, int expiryMinutes = 60);
}
