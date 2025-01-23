using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace RevitData.Infrastructure
{
    public class DataAccess
    {
        private readonly IMongoDatabase _database;

        public DataAccess()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string ConnectionString = configuration.GetSection("MongoDBSettings:ConnectionString").Value;
            string DatabaseName = configuration.GetSection("MongoDBSettings:DatabaseName").Value;

            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase(DatabaseName);
        }

        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            return _database.GetCollection<T>(collection);
        }

        public async Task<List<T>> GetDocumentsAsync<T>(string collection)
        {
            var mongoCollection = ConnectToMongo<T>(collection);
            return await mongoCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetDocumentByIdAsync<T>(string collection, string id)
        {
            var mongoCollection = ConnectToMongo<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await mongoCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task InsertDocumentAsync<T>(string collection, T document)
        {
            var mongoCollection = ConnectToMongo<T>(collection);
            await mongoCollection.InsertOneAsync(document);
        }

        public async Task InsertDocumentsAsync<T>(string collection, List<T> documents)
        {
            var mongoCollection = ConnectToMongo<T>(collection);
            await mongoCollection.InsertManyAsync(documents);
        }

        public async Task UpdateDocumentAsync<T>(string collection, string id, T document)
        {
            var mongoCollection = ConnectToMongo<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await mongoCollection.ReplaceOneAsync(filter, document, new ReplaceOptions { IsUpsert = true });
        }

        public async Task DeleteDocumentAsync<T>(string collection, string id)
        {
            var mongoCollection = ConnectToMongo<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await mongoCollection.DeleteOneAsync(filter);
        }

        public async Task InitializeWithIndexesAsync(Dictionary<string, List<string>> collectionIndexes)
        {
            var existingCollections = await _database.ListCollectionNames().ToListAsync();

            foreach (var entry in collectionIndexes)
            {
                string collectionName = entry.Key;
                List<string> indexFields = entry.Value;

                if (!existingCollections.Contains(collectionName))
                {
                    await _database.CreateCollectionAsync(collectionName);
                    Console.WriteLine($"Collection '{collectionName}' created.");
                }

                var collection = _database.GetCollection<BsonDocument>(collectionName);

                foreach (var field in indexFields)
                {
                    var indexKeys = Builders<BsonDocument>.IndexKeys.Ascending(field);
                    await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(indexKeys));
                    Console.WriteLine($"Index on '{field}' created for collection '{collectionName}'.");
                }
            }
        }
    }
}
