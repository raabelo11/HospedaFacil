using MongoDB.Driver;
using Microsoft.Extensions.Options;
using HospedaFacil.Domain.Models;

namespace HospedaFacil.Insfraestructure.Data.MongoDB.Repository
{
    public class HospedaFacilReadRepository
    {
        private readonly IMongoCollection<Hotel> _hoteisCollection;

        public HospedaFacilReadRepository(IOptions<MongoConnection> connection)
        {
            var client = new MongoClient(connection.Value.ConnectionString);
            var database = client.GetDatabase(connection.Value.Database);
            _hoteisCollection = database.GetCollection<Hotel>(connection.Value.HoteisCollectionName);
        }

        public async Task CriarHotelAsync(Hotel hotel)
        {
            await _hoteisCollection.InsertOneAsync(hotel);
        }
    }
}
