using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Models;
using Users_Api.Repositories.Interfaces;

namespace Users_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetAllAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(Guid Id)
        {
            return await _userRepo.GetByIdAsync(Id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            var newUser =  await _userRepo.CreateAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid Id ,[FromBody] User user)
        {
            if (Id != user.Id)
            {
                return BadRequest();
            }
            await _userRepo.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUser(Guid Id)
        {
            var user = await _userRepo.GetByIdAsync(Id);
            if (user==null)
            {
                return NotFound();
            }
            await _userRepo.Delete(user.Id);
            return NoContent();

        }
    }
}
