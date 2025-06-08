using HospedaFacil.Domain.Models;

namespace HospedaFacil.Insfraestructure.Interfaces
{
    public interface IHospedaFacilWriteRepository
    {
        Task<bool> AddHotel(Hotel hotel);
    }
}
