using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
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
        [SwaggerOperation(Summary ="This endpoint get All Users from database",
            Description ="You can get more information just try")]
        [SwaggerResponse(200 , "Everything works well")]
        [SwaggerResponse(400 , "Bad Request")]
        [SwaggerResponse(500,"Database Error")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetAllAsync();
        }
        [HttpGet("{Id}")]
        [SwaggerOperation(Summary = "This endpoint get single User from database",
         Description = "In this endpoint you can get detailed information about User")]
        [SwaggerResponse(200, "Everything works well")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "The User with the given ID was not found")]
        [SwaggerResponse(500, "Database Error")]
        public async Task<ActionResult<User>> GetUser(Guid Id)
        {
            var user = await _userRepo.GetByIdAsync(Id);
            if (user==null)
            {
                return NotFound("The User with the given ID was not found");
            }
            return user;
        }
        [SwaggerOperation(Summary = "This endpoint posted User to database",
         Description = "You have to add user information given parameters")]
        [SwaggerResponse(200, "The new user has been successfully added to the database")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Database Error")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            var newUser =  await _userRepo.CreateAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, newUser);
        }


        [SwaggerOperation(Summary = "This endpoint modifies the current User from the database",
         Description = "You must enter the id and information of the current user")]
        [SwaggerResponse(200, "The new user has been successfully updated")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Database Error")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid Id ,[FromBody] User user)
        {
            if (Id != user.Id)
            {
                return BadRequest("Given Id was not matched with given User Id");
            }
            await _userRepo.UpdateAsync(user);
            return Content("The new user has been successfully updated");
        }


        [SwaggerOperation(Summary = "This endpoint delete current user from the database",
         Description = "You must enter the id of the current user")]
        [SwaggerResponse(200, "The User has been successfully deleted from the database")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "The User with the given ID was not found")]
        [SwaggerResponse(500, "Database Error")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUser(Guid Id)
        {
            var user = await _userRepo.GetByIdAsync(Id);
            if (user==null)
            {
                return NotFound("The User with the given ID was not found");
            }
            await _userRepo.Delete(user.Id);
            return Content("The User has been successfully deleted from the database");

        }
    }
}
