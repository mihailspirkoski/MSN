using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Interfaces
{
    public interface IMusicRecordRepository<MusicRecord>
    {
        Task<List<MusicRecord>> GetAll();
        Task<MusicRecord> Get(string id);
        Task Insert(MusicRecord record);
        Task Update(MusicRecord record);
        Task Delete(MusicRecord record);
    }
}
