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
    public class MusicRecordService : IMusicRecordService
    {
        private readonly IMusicRecordRepository<MusicRecord> _musicRecordRepository;

        public MusicRecordService(IMusicRecordRepository<MusicRecord> musicRecordRepository)
        {
            _musicRecordRepository = musicRecordRepository;
        }

        public void CreateNewRecord(MusicRecord record)
        {
            _musicRecordRepository.Insert(record);
        }

        public void DeleteRecord(MusicRecord record)
        {
            _musicRecordRepository.Delete(record);
        }

        public List<MusicRecord> GetAllRecords()
        {
            return _musicRecordRepository.GetAll();
        }

        public MusicRecord GetRecord(int id)
        {
            return _musicRecordRepository.Get(id);
        }

        public void UpdateRecord(MusicRecord record)
        {
            _musicRecordRepository.Update(record);
        }
    }
}
