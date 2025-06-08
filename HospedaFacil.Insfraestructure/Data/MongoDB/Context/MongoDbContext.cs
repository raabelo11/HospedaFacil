using MongoDB.Driver;

namespace HospedaFacil.Insfraestructure.Data.MongoDB.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(MongoConnection connection)
        {
            var client = new MongoClient(connection.ConnectionString);
            _database = client.GetDatabase(connection.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}