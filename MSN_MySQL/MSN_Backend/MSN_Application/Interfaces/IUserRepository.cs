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
        List<MSNUSer> GetAll();
        MSNUSer Get(string userID);
        void Update(MSNUser user);
        void Delete(MSNUser user);

    }
}
