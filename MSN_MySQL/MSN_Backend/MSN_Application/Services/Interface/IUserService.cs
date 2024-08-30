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
        List<MSNUser> GetAllUsers();
        MSNUser GetUser(string id);
        void UpdateUser(MSNUser user);
        void DeleteUser(MSNUser user);
    }
}
