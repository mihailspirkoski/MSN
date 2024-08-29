using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Interfaces
{
    public interface IForumPostRepository<ForumPost>
    {
        Task<List<ForumPost>> GetAll();
        Task<ForumPost> Get(string id);
        Task Insert (ForumPost post);
        Task Update (ForumPost post);
        Task Delete (ForumPost post);
    }
}
