using HospedaFacil.Domain.Models;

namespace HospedaFacil.Insfraestructure.Interfaces
{
    public interface IHospedaFacilReadRepository
    {
        Task<List<Hotel>> BuscarTodosAsync();
    }
}
