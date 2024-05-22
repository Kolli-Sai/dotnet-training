using Authentication.Contracts;
using Authentication.Data;
using Authentication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Services
{
    public  class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationContext _context;
        public UserService(IConfiguration configuration, AuthenticationContext context)
        {
            this._configuration = configuration;
            this._context = context;

        }
      async   Task<string> IUserService.Login(User newUser)
        {
            User nameMatching =await _context.Users.Where(u => u.UserName == newUser.UserName).FirstOrDefaultAsync();
            if (nameMatching == null)
            {
                return "Invalid Creadentials.";
            }

            if(nameMatching.UserName != newUser.UserName)
            {
                return "Invalid UserName";
            }

            if (newUser.Password != nameMatching.Password)
            {
                return "Invalid password.";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTTokens:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
    {
        new Claim(ClaimTypes.Name, nameMatching.UserName),

    }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);

            return userToken;

        }
    }
}
