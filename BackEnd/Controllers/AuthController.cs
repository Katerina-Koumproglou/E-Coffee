using System.Data.SqlTypes;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BackEnd.BusinessLogic;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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
            try
            {
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
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });

            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.Authenticate(model.email, model.password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    userId = user.ID,
                    name = user.name,
                    surname = user.surname,
                    address = user.address,
                    email = user.email,
                    phone = user.phone
                }
            });
        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "default_secret_key");
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.ID.ToString()),
                new Claim("name", user.name),
                new Claim("email", user.email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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