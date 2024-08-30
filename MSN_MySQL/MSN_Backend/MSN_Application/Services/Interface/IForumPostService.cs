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
        List<ForumPost> GetAllPosts();
        ForumPost GetPost(int id);
        void CreateNewPost(ForumPost record);
        void UpdatePost(ForumPost record);
        void DeletePost(ForumPost record);
    }
}
