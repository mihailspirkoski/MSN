using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MSN_Application.Services.Interface;
using MSN_Application.Utility;
using MSN_Domain.Entities;
using MSN_WebApi.ViewModels;
using MSN_WebApi.ViewModels_DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MSN_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDTO registerDTO)
        {
            if(registerDTO.email == "" || registerDTO.password == "")
            {
                return BadRequest("");
            }
            var tryUser = await _userService.GetUser(registerDTO.email);
            if(tryUser != null)
            {
                return BadRequest("");
            }
            
            var user = new MSNUser()
            {
                email = registerDTO.email,
                password = BCrypt.Net.BCrypt.HashPassword(registerDTO.password),
                firstname = registerDTO.firstname,
                lastname = registerDTO.lastname,
                age = registerDTO.age,
                role = SD.Role_StandardUser,
            };
            await _userService.CreateUser(user);
            return Ok(GenerateJWTToken(user));
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDTO loginDTO)
        {
            var user = await _userService.GetUser(loginDTO.email);
            if(user == null)
            {
                return BadRequest("");
            }
            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.password, user.password);
            if (checkPassword)
            {
                return Ok(GenerateJWTToken(user));
            }
            else return BadRequest("");
            

        }

        private string GenerateJWTToken(MSNUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {

                new Claim("Id", user.Id),
                new Claim("Firstname", user.firstname),
                new Claim("Lastname", user.lastname),
                new Claim("Email", user.email),
                new Claim("Role", user.role),
                new Claim("Age", user.age.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
