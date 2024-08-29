using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Services.Interface
{
    public interface IUserService
    {
        Task<List<MSNUser>> GetAllUsers();
        Task<MSNUser> GetUser(string id);
        Task UpdateUser(MSNUser user);
        Task DeleteUser(MSNUser user);
        Task CreateUser(MSNUser user);
    }
}
