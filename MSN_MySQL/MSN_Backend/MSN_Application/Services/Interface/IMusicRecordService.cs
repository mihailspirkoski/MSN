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
        List<MusicRecord> GetAllRecords();
        MusicRecord GetRecord(int id);
        void CreateNewRecord(MusicRecord record);
        void UpdateRecord(MusicRecord record);
        void DeleteRecord(MusicRecord record);


    }
}
