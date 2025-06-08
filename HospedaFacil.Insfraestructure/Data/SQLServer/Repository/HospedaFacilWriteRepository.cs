using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Data.SQLServer.Context;
using HospedaFacil.Insfraestructure.Interfaces;
using MongoDB.Bson;

namespace HospedaFacil.Insfraestructure.Data.SQLServer.Repository
{
    public class HospedaFacilWriteRepository(SqlServerDbContext context) : IHospedaFacilWriteRepository
    {
        private readonly SqlServerDbContext _context = context;

        public async Task<bool> AddHotel(Hotel hotel)
        {
            try
            {
                hotel.MongoId = ObjectId.GenerateNewId().ToString();
                await _context.Hoteis.AddAsync(hotel);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}, {ex.StackTrace}");
            }
        }
    }
}
