using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSN_Application.Services.Interface;
using MSN_Application.Utility;
using MSN_Domain.Entities;
using MSN_WebApi.ViewModels_DTO;

namespace MSN_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private UserManager<MSNUser> _userManager;

        public UserController(IUserService userService, UserManager<MSNUser> userManager)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<MSNUser> allUsers = _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("get-user/{email}")]
        public async Task<IActionResult> GetUser([FromRoute(Name = "email")] string email)
        {
            MSNUser user = _userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            return Ok(user);
        }

        [HttpPost("change-permissions")]
        public async Task<IActionResult> ChangeUserPermissions(ChangeRoleDTO changeRoleDTO)
        {
            MSNUser user = _userManager.FindByEmailAsync(changeRoleDTO.email).GetAwaiter().GetResult();
            if(changeRoleDTO.role == SD.Role_StandardUser)
            {
                _userManager.RemoveFromRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, SD.Role_StandardUser).GetAwaiter().GetResult();
            }
            else if(changeRoleDTO.role == SD.Role_Admin) 
            {
                _userManager.RemoveFromRoleAsync(user, SD.Role_StandardUser).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            else
            {
                return BadRequest("Unrecognized Role");
            }

            user.role = changeRoleDTO.role;
            _userService.UpdateUser(user);

            return Ok();

        }
    }
}
