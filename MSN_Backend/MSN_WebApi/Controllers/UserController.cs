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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<MSNUser> allUsers = await _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("get-user/{email}")]
        public async Task<IActionResult> GetUser([FromRoute(Name = "email")] string email)
        {
            MSNUser user = await _userService.GetUser(email);
            return Ok(user);
        }

        [HttpPost("change-permissions")]
        public async Task<IActionResult> ChangeUserPermissions(ChangeRoleDTO changeRoleDTO)
        {
            if(changeRoleDTO.role == SD.Role_Admin || changeRoleDTO.role == SD.Role_StandardUser) { 
            MSNUser user = await _userService.GetUser(changeRoleDTO.email);
            user.role = changeRoleDTO.role;
            await _userService.UpdateUser(user);
            return Ok();
            }
            else
            {
                return BadRequest("");
            }


        }
    }
}
