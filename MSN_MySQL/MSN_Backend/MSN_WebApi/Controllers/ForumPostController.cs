using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using MSN_Application.Services.Implementation;
using MSN_Application.Services.Interface;
using MSN_Domain.Entities;
using MSN_Domain.Enums;
using MSN_WebApi.ViewModels_DTO;
using System.IdentityModel.Tokens.Jwt;

namespace MSN_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostController : ControllerBase
    {
        private readonly IForumPostService _forumPostService;
        private readonly UserManager<MSNUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _context;

        public ForumPostController(IForumPostService forumPostService, UserManager<MSNUser> userManager, 
            IConfiguration configuration, IHttpContextAccessor context)
        {
            _forumPostService = forumPostService;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        [Authorize]
        [HttpPost("add-post")]
        public async Task<IActionResult> CreatePost(ForumPostDTO forumPostDTO)
        {

            var accessToken = _context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(accessToken);


            var username = token.Claims.ElementAt(3).Value;


            MSNUser user = _userManager.FindByEmailAsync(username).GetAwaiter().GetResult();
            string userId = user.UserName;

            ForumPost forumPost = new ForumPost();
            forumPost.title = forumPostDTO.title;
            forumPost.description = forumPostDTO.description;
            forumPost.artist = forumPostDTO.artist;
            forumPost.genre = forumPostDTO.genre;
            forumPost.type = forumPostDTO.type;
            forumPost.timeCreated = DateTime.UtcNow;
            forumPost.isApproved = false;
            forumPost.createdBy = user;
            forumPost.userName = userId;

            _forumPostService.CreateNewPost(forumPost);

            return Ok("Created");
        }

        [HttpPost("approve-post")]
        public async Task<IActionResult> ApprovePost(ApproveForumPostDTO toApprove)
        {
            
            if(toApprove.Id == null || toApprove.Id == 0)
            {
                return BadRequest("");
            }

            ForumPost forumPost = _forumPostService.GetPost(toApprove.Id);
            if (toApprove.isApproved == "true")
            {
                forumPost.isApproved = true;
            }
            else if (toApprove.isApproved == "false")
            {
                forumPost.isApproved = false;
            }
            else return BadRequest("");


            _forumPostService.UpdatePost(forumPost);
            return Ok();
        }
        
        [HttpGet("get-all-posts")]
        public async Task<IActionResult> GetAllForumPosts()
        {
            List<ForumPost> forumPosts = _forumPostService.GetAllPosts();
            return Ok(forumPosts);
        }

        [HttpGet("get-single-post/{postId}")]
        public async Task<IActionResult> GetASingleRecord([FromRoute(Name = "postId")] string id)
        {
            int postId = Int32.Parse(id);
            ForumPost forumPost = _forumPostService.GetPost(postId);
            return Ok(forumPost);
        }
    }
}
