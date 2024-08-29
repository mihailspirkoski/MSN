using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using MSN_Application.Services.Implementation;
using MSN_Application.Services.Interface;
using MSN_Domain.Entities;
using MSN_WebApi.ViewModels_DTO;
using System.IdentityModel.Tokens.Jwt;

namespace MSN_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostController : ControllerBase
    {
        private readonly IForumPostService _forumPostService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;


        public ForumPostController(IForumPostService forumPostService, IUserService userService, 
            IConfiguration configuration)
        {
            _forumPostService = forumPostService;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("add-post")]
        public async Task<IActionResult> CreatePost(ForumPostDTO forumPostDTO)
        {

            ForumPost forumPost = new ForumPost();
            forumPost.title = forumPostDTO.title;
            forumPost.description = forumPostDTO.description;
            forumPost.artist = forumPostDTO.artist;
            forumPost.genre = forumPostDTO.genre;
            forumPost.type = forumPostDTO.type;
            forumPost.timeCreated = DateTime.UtcNow;
            forumPost.isApproved = false;
            forumPost.createdBy = await _userService.GetUser(forumPostDTO.email);
            forumPost.userName = forumPostDTO.email;

            await _forumPostService.CreateNewPost(forumPost);

            return Ok("Created");
        }

        [HttpPost("approve-post")]
        public async Task<IActionResult> ApprovePost(ApproveForumPostDTO toApprove)
        {
            
            if(toApprove.Id == null || toApprove.Id == "")
            {
                return BadRequest("");
            }

            ForumPost forumPost = await _forumPostService.GetPost(toApprove.Id);
            if (toApprove.isApproved == "true")
            {
                forumPost.isApproved = true;
            }
            else if (toApprove.isApproved == "false")
            {
                forumPost.isApproved = false;
            }
            else return BadRequest("");


            await _forumPostService.UpdatePost(forumPost);
            return Ok();
        }
        
        [HttpGet("get-all-posts")]
        public async Task<IActionResult> GetAllForumPosts()
        {
            List<ForumPost> forumPosts = await _forumPostService.GetAllPosts();
            return Ok(forumPosts);
        }

        [HttpGet("get-single-post/{postId}")]
        public async Task<IActionResult> GetASingleRecord([FromRoute(Name = "postId")] string id)
        {

            ForumPost forumPost = await _forumPostService.GetPost(id);
            return Ok(forumPost);
        }
    }
}
