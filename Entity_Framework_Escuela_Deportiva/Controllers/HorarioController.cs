using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class HorarioController : Controller
    {
        private readonly EscuelaDeportivaContext _context;

        public HorarioController(EscuelaDeportivaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTrainingSchedules()
        {
            var lista = await _context.Horarios.ToListAsync();
            string JsonResult = JsonConvert.SerializeObject(lista, Formatting.Indented);
            return Json(JsonResult);
        }
    }


}
