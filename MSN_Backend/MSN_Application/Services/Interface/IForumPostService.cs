using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Services.Interface
{
    public interface IForumPostService
    {
        Task<List<ForumPost>> GetAllPosts();
        Task<ForumPost> GetPost(string id);
        Task CreateNewPost(ForumPost record);
        Task UpdatePost(ForumPost record);
        Task DeletePost(ForumPost record);
    }
}
