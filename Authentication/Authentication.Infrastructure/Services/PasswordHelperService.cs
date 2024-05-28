using Authentication.Core.Contracts.Services;
using Authentication.Core.Entities;
using Authentication.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.Infrastructure.Services;

public class PasswordHelperService:IPasswordHelperService
{
    public byte[] GenerateSalt(int size = 16)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] salt = new byte[size];
            rng.GetBytes(salt);
            return salt;
        }

    }

    public byte[] GenerateHash(string password, byte[] salt)
    {
        using (var hmac = new HMACSHA512(salt))
        {
            return hmac.ComputeHash(password.GetByteArray());
        }
    }

    public bool VerifyPassword(string passwordToBeHashed, byte[] salt, byte[] hashedPassword)
    {
        byte[] passwordHash = GenerateHash(passwordToBeHashed, salt);   
        return passwordHash.SequenceEqual(hashedPassword);
    }

    public  string GenerateToken(User user, string secretKey, int expiryMinutes = 60)
    {
        // Create security key
        var key = new SymmetricSecurityKey(secretKey.GetByteArray());

        // Create credentials
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Create the JWT token handler
        var tokenHandler = new JwtSecurityTokenHandler();

        // Create claims
        var claims = new[]
        {
            new Claim(ClaimTypes.Name,user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
           
            new Claim(ClaimTypes.Role,user.Role.ToString())
        };

        // Create the token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
            SigningCredentials = credentials
        };

        // Create the token
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // Return the serialized token
        return tokenHandler.WriteToken(token);
    }


}
