using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        private readonly UserManager<MSNUser> _userManager;
        private readonly SignInManager<MSNUser> _signInManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<MSNUser> userManager, SignInManager<MSNUser> signInManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDTO registerDTO)
        {
            var user = new MSNUser()
            {
                UserName = registerDTO.email,
                PasswordHash = registerDTO.password,
                firstname = registerDTO.firstname,
                lastname = registerDTO.lastname,
                age = registerDTO.age,
                role = SD.Role_StandardUser,
                Email = registerDTO.email
            };
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if(result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, SD.Role_StandardUser).GetAwaiter().GetResult();
                return Ok(GenerateJWTToken(user));
            }
            else
            {
                return BadRequest("Problem creating user");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.email);
            var result = await _signInManager.PasswordSignInAsync(userName: loginDTO.email, password: loginDTO.password, isPersistent: false, lockoutOnFailure:false);

            if(result.Succeeded)
            {
                return Ok(GenerateJWTToken(user));
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        private string GenerateJWTToken(MSNUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.firstname),
                new Claim(ClaimTypes.Surname, user.lastname),
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.Role, user.role),
                new Claim(ClaimTypes.Version, user.age.ToString())
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
