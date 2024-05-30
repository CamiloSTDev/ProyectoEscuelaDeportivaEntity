using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Entity_Framework_Escuela_Deportiva.api
{
    [ApiController]

    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        private readonly EscuelaDeportivaContext _context;


        public HorariosController(EscuelaDeportivaContext context)

        {

            _context = context;

        }

        [HttpGet]
        public IActionResult GetHorarios()
        {
            var horarios = _context.Horarios.ToList();
            var events = horarios.Select(h => new HorarioFullCalendarDTO(h));
            var json = System.Text.Json.JsonSerializer.Serialize(events);
            return Content(json, "application/json");
        }
    }
}
