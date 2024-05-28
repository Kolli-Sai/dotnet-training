using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Dtos;
using Authentication.Core.Entities;
using Authentication.Core.Enums;
using Authentication.Core.Options;
using Authentication.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelperService _passwordHelperService;
        private readonly JwtTokenOptions _jwtTokenOptions;

        public UserController(IUserRepository userRepository, IPasswordHelperService passwordHelperService, IOptions<JwtTokenOptions> options)
        {
            _userRepository = userRepository;
            _passwordHelperService = passwordHelperService;
            _jwtTokenOptions = options.Value;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterVm user)
        {
            try
            {
                // Check if user already exists in the database by email
                var userFound = await _userRepository.GetUserByEmailAsync(user.Email);
                if (userFound != null)
                {
                    return Conflict(new ErrorResponseDto
                    {
                        Success = false,
                        Message = "User already exists."
                    });
                }

                var salt = _passwordHelperService.GenerateSalt();
                var hashedPassword = _passwordHelperService.GenerateHash(user.Password, salt);

                var newUser = new User
                {
                    Email = user.Email,
                    Id = Guid.NewGuid(),
                    PasswordHash = hashedPassword,
                    PasswordSalt = salt,
                    Role = UserRole.User
                };

                var userCreated = await _userRepository.CreateUserAsync(newUser);

                if (!userCreated)
                {
                    return BadRequest(new ErrorResponseDto
                    {
                        Success = false,
                        Message = "Failed to register user."
                    });
                }

                return Ok(new SuccessResponseDto
                {
                    Success = true,
                    Message = "User created successfully."
                });
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown in this snippet)
                return StatusCode(500, new ErrorResponseDto
                {
                    Success = false,
                    Message = "An error occurred while processing your request."
                });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginVm user)
        {
            try
            {
                var userExists = await _userRepository.GetUserByEmailAsync(user.Email);

                if (userExists == null)
                {
                    return NotFound(new ErrorResponseDto
                    {
                        Success = false,
                        Message = "User does not exist."
                    });
                }

                var passwordVerified = _passwordHelperService.VerifyPassword(user.Password, userExists.PasswordSalt, userExists.PasswordHash);
                if (!passwordVerified)
                {
                    return Unauthorized(new ErrorResponseDto
                    {
                        Success = false,
                        Message = "Invalid password."
                    });
                }

                var token = _passwordHelperService.GenerateToken(userExists, _jwtTokenOptions.Key);
                if (string.IsNullOrEmpty(token))
                {
                    return StatusCode(500, new ErrorResponseDto
                    {
                        Success = false,
                        Message = "Failed to generate token."
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown in this snippet)
                return StatusCode(500, new ErrorResponseDto
                {
                    Success = false,
                    Message = "An error occurred while processing your request."
                });
            }
        }
    }
}
