using MongoDB.Driver;
using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Data.MongoDB.Context;
using HospedaFacil.Insfraestructure.Interfaces;

namespace HospedaFacil.Insfraestructure.Data.MongoDB.Repository
{
    public class HospedaFacilReadRepository(MongoDbContext context) : IHospedaFacilReadRepository
    {
        private readonly IMongoCollection<Hotel> _hoteis = context.GetCollection<Hotel>("Hoteis");

        public async Task<List<Hotel>> BuscarTodosAsync()
        {
            return await _hoteis.Find(h => true).ToListAsync();
        }

        //public async Task<Hotel> BuscarPorIdAsync(string id)
        //{
        //    return await _hoteis.Find(h => h.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task CriarHotelAsync(Hotel hotel)
        //{
        //    await _hoteis.InsertOneAsync(hotel);
        //}
    }
}