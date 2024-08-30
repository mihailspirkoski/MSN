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
    public class UserService : IUserService
    {

        private readonly IUserRepository<MSNUser> _userRepository;

        public UserService(IUserRepository<MSNUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(MSNUser user)
        {
            _userRepository.Delete(user);
        }

        public List<MSNUser> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public MSNUser GetUser(string id)
        {
            return _userRepository.Get(id);
        }

        public void UpdateUser(MSNUser user)
        {
            _userRepository.Update(user);
        }
    }
}
