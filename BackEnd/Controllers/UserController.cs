using BackEnd.BusinessLogic;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("users")]
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return user;
        }

        [HttpPatch("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = await _userService.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound(new { message = "User not found." });
            }

            existingUser.name = updatedUser.name ?? existingUser.name;
            existingUser.surname = updatedUser.surname ?? existingUser.surname;
            existingUser.phone = updatedUser.phone ?? existingUser.phone;
            existingUser.address = updatedUser.address ?? existingUser.address;

            //Email verification
            var emailExists = await _userService.GetUserByEmail(updatedUser.email);
            if (emailExists != null && emailExists.ID != id)
            {
                return BadRequest(new { message = "Email exists already." });
            }
            existingUser.email = updatedUser.email;

            //Password hashed safely
            if (!string.IsNullOrEmpty(updatedUser.password))
            {
                existingUser.password = BCrypt.Net.BCrypt.HashPassword(updatedUser.password);

            }
            await _userService.UpdateUser(existingUser);
            return Ok(new { message = "User updated successfully." });
        }
    }
}