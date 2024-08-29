using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Interfaces
{
    public interface IUserRepository<MSNUSer> 
    {
        Task<List<MSNUSer>> GetAll();
        Task<MSNUSer> Get(string userID);
        Task Update(MSNUser user);
        Task Delete(MSNUser user);
        Task Insert(MSNUser user);

    }
}
