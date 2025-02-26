using System.Data.SqlTypes;
using BackEnd.BusinessLogic;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            var existingUser = await _userService.Authenticate(model.email, model.password);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Email is already in use." });
            }

            var newUser = new User
            {
                name = model.name,
                surname = model.surname,
                address = model.address,
                phone = model.phone,
                email = model.email
            };

            await _userService.SignUp(newUser, model.password);
            return Ok(new { message = "User created successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.Authenticate(model.email, model.password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(new { userId = user.ID, name = user.name, surname = user.surname, address = user.address, email = user.email, phone = user.phone });
        }

        public class RegisterModel
        {
            public string name { get; set; } = "";
            public string surname { get; set; } = "";
            public string address { get; set; } = "";
            public string phone { get; set; } = "";
            public string email { get; set; } = "";
            public string password { get; set; } = "";
        }

        public class LoginModel
        {
            public string email { get; set; } = "";
            public string password { get; set; } = "";
        }
    }
}