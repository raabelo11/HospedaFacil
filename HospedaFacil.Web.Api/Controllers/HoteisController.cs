using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospedaFacil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoteisController(IHospedaFacilWriteRepository writeRepository, IHospedaFacilReadRepository readRepository) : Controller
    {
        private readonly IHospedaFacilWriteRepository _writeRepository = writeRepository;
        private readonly IHospedaFacilReadRepository _readRepository = readRepository;

        [HttpPost]
        public async Task<ActionResult<GenericReturnValue>> AddHotel([FromBody] Hotel hotel)
        {
            var resp = await _writeRepository.AddHotel(hotel);
            var ret = new GenericReturnValue();
            ret.data = resp;

            return Ok(ret);
        }

        [HttpGet]
        public async Task<ActionResult<GenericReturnValue>> ListHotel()
        {
            var resp = await _readRepository.BuscarTodosAsync();
            var ret = new GenericReturnValue();
            ret.data = resp;

            return Ok(ret);
        }
    }
}
