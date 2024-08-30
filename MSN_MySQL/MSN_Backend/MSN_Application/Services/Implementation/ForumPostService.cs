using MSN_Application.Interfaces;
using MSN_Application.Services.Interface;
using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Services.Implementation
{
    public class ForumPostService : IForumPostService
    {
        private readonly IForumPostRepository<ForumPost> _forumPostRepository;

        public ForumPostService(IForumPostRepository<ForumPost> forumPostRepository)
        {
            _forumPostRepository = forumPostRepository;
        }


        public void CreateNewPost(ForumPost post)
        {
            _forumPostRepository.Insert(post);
        }

        public void DeletePost(ForumPost post)
        {
           _forumPostRepository.Delete(post);
        }

        public List<ForumPost> GetAllPosts()
        {
            return _forumPostRepository.GetAll();
        }

        public ForumPost GetPost(int id)
        {
            return _forumPostRepository.Get(id);
        }

        public void UpdatePost(ForumPost post)
        {
            _forumPostRepository.Update(post);
        }
    }
}
