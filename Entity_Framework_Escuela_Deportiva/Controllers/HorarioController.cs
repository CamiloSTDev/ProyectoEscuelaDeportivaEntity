using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class HorarioController : Controller
    {
        private readonly EscuelaDeportivaContext _context;

        public HorarioController(EscuelaDeportivaContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _context.Horarios.ToListAsync());
        }

        public JsonResult GetTrainingSchedules()
        {
            using (var dbContext = new EscuelaDeportivaContext())
            {
                var trainingSchedules = dbContext.Horarios.ToList();
                return Json(trainingSchedules);
            }
        }

    }
}
