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

        public async Task CreateUser(MSNUser user)
        {
            await _userRepository.Insert(user);
        }

        public async Task DeleteUser(MSNUser user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<List<MSNUser>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<MSNUser> GetUser(string id)
        {
            return await _userRepository.Get(id);
        }

        public async Task UpdateUser(MSNUser user)
        {
            await _userRepository.Update(user);
        }
    }
}
