using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Interfaces
{
    public interface IForumPostRepository<ForumPost>
    {
        List<ForumPost> GetAll();
        ForumPost Get(int id);
        void Insert (ForumPost post);
        void Update (ForumPost post);
        void Delete (ForumPost post);
    }
}
