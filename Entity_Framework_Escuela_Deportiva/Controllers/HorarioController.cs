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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Horarios.ToListAsync());
        }

        public async Task<IActionResult> GetTrainingSchedules()
        {
            var horarios = await _context.Horarios.ToListAsync();
            var events = horarios.Select(h => new {
                title = h.Grupos,
                date=h.Fecha,
                start = h.HoraInicio,
                end = h.HoraFin
            });
            return Json(new { data = events });
        }
    }


}
