using HospedaFacil.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospedaFacil.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthenticationController : ControllerBase
    {


        [HttpPost]
        public IActionResult RegistraUsuario(RegistraUsuarioDTO registraUsuarioDTO)
        {




            return Ok();
        }
    }
}
