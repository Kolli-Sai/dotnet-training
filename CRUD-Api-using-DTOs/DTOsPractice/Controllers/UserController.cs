using AutoMapper;
using DTOsPractice.Config;
using DTOsPractice.DataBase;
using DTOsPractice.DTOs;
using DTOsPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTOsPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DTOPracticeDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public UserController(DTOPracticeDatabaseContext dbContext,IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> Get()
        {
            List<UserResponseDTO> users = await _dbContext.Users.Select(user => new UserResponseDTO
            {
                UserId = user.UserId,
                UserAge = user.UserAge,
                UserName = user.UserName
            }).ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetById(int id)
        {
            User user = await _dbContext.Users.FindAsync(id);

            var userResponse = new UserResponseDTO
            {
                UserId = user.UserId,
                UserAge = user.UserAge,
                UserName = user.UserName
            };
            return Ok(userResponse);

        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Post(CreateUserRequestDTO request)
        {
            var user = _mapper.Map<User>(request);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            UserResponseDTO response = _mapper.Map<UserResponseDTO>(user);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateUserRequestDTO request)
        {
            if (request.UserId != id)
            {
                return BadRequest();
            }

            User userFound = await _dbContext.Users.FindAsync(id);

            if (userFound == null)
            {
                return NotFound();
            }

            _dbContext.Entry(userFound).CurrentValues.SetValues(request);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            User userFound = await _dbContext.Users.FindAsync(id);
            if (userFound == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(userFound);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
