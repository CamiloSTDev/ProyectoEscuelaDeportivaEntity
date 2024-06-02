using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class ForoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
