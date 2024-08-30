using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Interfaces
{
    public interface IMusicRecordRepository<MusicRecord>
    {
        List<MusicRecord> GetAll();
        MusicRecord Get(int id);
        void Insert(MusicRecord record);
        void Update(MusicRecord record);
        void Delete(MusicRecord record);
    }
}
