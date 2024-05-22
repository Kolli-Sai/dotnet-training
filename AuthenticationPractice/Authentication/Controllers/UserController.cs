using Authentication.Contracts;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpPost]
       
        public async Task<ActionResult<string>> Post(User newUser)
        {
            string token =await _userService.Login(newUser);
            
            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return Ok("Get Method");
        }
    }
}
