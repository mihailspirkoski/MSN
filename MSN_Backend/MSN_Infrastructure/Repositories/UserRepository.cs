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
    public class UserRepository : IUserRepository<MSNUser>
    {
        private readonly IMongoCollection<MSNUser> _usersCollection;

        public UserRepository(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
               dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<MSNUser>(
                dbSettings.Value.MSNUserCollectionName);
        }

        public async Task Delete(MSNUser user)
        {
            await _usersCollection.DeleteOneAsync(z => z.Id == user.Id);
        }

        public async Task<MSNUser> Get(string userID)
        {
            return await _usersCollection.Find(z => z.email == userID).FirstOrDefaultAsync();
        }

        public async Task<List<MSNUser>> GetAll()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task Insert(MSNUser user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task Update(MSNUser user)
        {
            await _usersCollection.ReplaceOneAsync(z => z.Id == user.Id, user);
        }
    }
}
