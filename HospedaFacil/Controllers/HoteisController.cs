using Microsoft.AspNetCore.Mvc;

namespace HospedaFacil.Controllers
{
    public class HoteisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
