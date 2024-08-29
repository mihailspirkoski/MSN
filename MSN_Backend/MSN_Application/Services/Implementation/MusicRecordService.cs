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

        public async Task CreateNewRecord(MusicRecord record)
        {
            await _musicRecordRepository.Insert(record);
        }

        public async Task DeleteRecord(MusicRecord record)
        {
            await _musicRecordRepository.Delete(record);
        }

        public async Task<List<MusicRecord>> GetAllRecords()
        {
            return await _musicRecordRepository.GetAll();
        }

        public async Task<MusicRecord> GetRecord(string id)
        {
            return await _musicRecordRepository.Get(id);
        }

        public async Task UpdateRecord(MusicRecord record)
        {
            await _musicRecordRepository.Update(record);
        }
    }
}
