using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Application.Services.Interface
{
    public interface IMusicRecordService
    {
        Task<List<MusicRecord>> GetAllRecords();
        Task<MusicRecord> GetRecord(string id);
        Task CreateNewRecord(MusicRecord record);
        Task UpdateRecord(MusicRecord record);
        Task DeleteRecord(MusicRecord record);


    }
}
