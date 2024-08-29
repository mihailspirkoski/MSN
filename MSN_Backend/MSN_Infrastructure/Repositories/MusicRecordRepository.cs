using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MSN_Application.Interfaces;
using MSN_Domain.Entities;
using MSN_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Infrastructure.Repositories
{
    public class MusicRecordRepository : IMusicRecordRepository<MusicRecord>
    {

        private readonly IMongoCollection<MusicRecord> _musicRecordsCollection;

        public MusicRecordRepository(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
              dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _musicRecordsCollection = mongoDatabase.GetCollection<MusicRecord>(
                dbSettings.Value.MusicRecordCollectionName);
        }


        public async Task Delete(MusicRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }
            await _musicRecordsCollection.DeleteOneAsync(z => z.Id == record.Id);
        }

        public async Task<MusicRecord> Get(string id)
        {
            return await _musicRecordsCollection.Find(z => z.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MusicRecord>> GetAll()
        {
            return await _musicRecordsCollection.Find(_ => true).ToListAsync();
        }

        public async Task Insert(MusicRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            await _musicRecordsCollection.InsertOneAsync(record);
        }

        public async Task Update(MusicRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            await _musicRecordsCollection.ReplaceOneAsync(z => z.Id == record.Id, record);
        }
    }
}
