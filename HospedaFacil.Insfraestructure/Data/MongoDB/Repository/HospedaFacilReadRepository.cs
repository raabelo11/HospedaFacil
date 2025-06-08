using MongoDB.Driver;
using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Data.MongoDB.Context;
using HospedaFacil.Insfraestructure.Interfaces;

namespace HospedaFacil.Insfraestructure.Data.MongoDB.Repository
{
    public class HospedaFacilReadRepository : IHospedaFacilReadRepository
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Hotel> _hotel;

        public HospedaFacilReadRepository(MongoDbContext context)
        {
            _context = context;
            _hotel = _context.GetCollection<Hotel>("Hoteis");
        }

        public async Task<List<Hotel>> BuscarTodos()
        {
            return await _hotel.Find(p => true).ToListAsync();
        }
    }
}