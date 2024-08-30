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
    public class UserRepository : IUserRepository<MSNUser>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(MSNUser user)
        {
            _context.MSNUsers.Remove(user);
            _context.SaveChanges();
        }

        public MSNUser Get(string userID)
        {
            return _context.MSNUsers.SingleOrDefault(z => z.Id == userID);
        }

        public List<MSNUser> GetAll()
        {
            return _context.MSNUsers.ToList();
        }

        public void Update(MSNUser user)
        {
            _context.MSNUsers.Update(user);
            _context.SaveChanges();
        }
    }
}
