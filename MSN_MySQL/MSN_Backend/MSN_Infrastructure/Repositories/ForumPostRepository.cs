using MSN_Application.Interfaces;
using MSN_Domain.Entities;
using MSN_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Infrastructure.Repositories
{
    public class ForumPostRepository : IForumPostRepository<ForumPost>
    {

        private readonly ApplicationDbContext _context;

        public ForumPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(ForumPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            _context.ForumPosts.Remove(post);
            _context.SaveChanges();
        }

        public ForumPost Get(int id)
        {
            return _context.ForumPosts.SingleOrDefault(z => z.Id == id);
        }

        public List<ForumPost> GetAll()
        {
            return _context.ForumPosts.ToList();
        }

        public void Insert(ForumPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            _context.ForumPosts.Add(post);
            _context.SaveChanges();
        }

        public void Update(ForumPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
            _context.ForumPosts.Update(post);
            _context.SaveChanges();
        }
    }
}
