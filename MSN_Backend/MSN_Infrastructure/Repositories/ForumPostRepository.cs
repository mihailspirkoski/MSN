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
    public class ForumPostRepository : IForumPostRepository<ForumPost>
    {

        private readonly IMongoCollection<ForumPost> _forumPostCollection;

        public ForumPostRepository(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(
               dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSettings.Value.DatabaseName);

            _forumPostCollection = mongoDatabase.GetCollection<ForumPost>(
                dbSettings.Value.ForumPostCollectionName);
        }

        public async Task Delete(ForumPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            await _forumPostCollection.DeleteOneAsync(z => z.Id == post.Id);
        }

        public async Task<ForumPost> Get(string id)
        {
            return await _forumPostCollection.Find(z => z.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ForumPost>> GetAll()
        {
            return await _forumPostCollection.Find(_ => true).ToListAsync();
        }

        public async Task Insert(ForumPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            await _forumPostCollection.InsertOneAsync(post);
        }

        public async Task Update(ForumPost post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
            await _forumPostCollection.ReplaceOneAsync(z => z.Id == post.Id, post);
        }
    }
}
