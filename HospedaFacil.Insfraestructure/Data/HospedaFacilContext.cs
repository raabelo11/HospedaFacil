using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace HospedaFacil.Insfraestructure.Data
{
    public class HospedaFacilContext
    {
        private readonly IMongoDatabase _database;

        public HospedaFacilContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
    }
}
