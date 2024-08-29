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


        public async Task CreateNewPost(ForumPost post)
        {
            await _forumPostRepository.Insert(post);
        }

        public async Task DeletePost(ForumPost post)
        {
            await _forumPostRepository.Delete(post);
        }

        public async Task<List<ForumPost>> GetAllPosts()
        {
            return await _forumPostRepository.GetAll();
        }

        public async Task<ForumPost> GetPost(string id)
        {
            return await _forumPostRepository.Get(id);
        }

        public async Task UpdatePost(ForumPost post)
        {
            await _forumPostRepository.Update(post);
        }
    }
}
