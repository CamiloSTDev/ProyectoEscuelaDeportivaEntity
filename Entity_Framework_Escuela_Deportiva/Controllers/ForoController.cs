using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class ForoController : Controller
    {
       private readonly EscuelaDeportivaContext _context;

        public ForoController(EscuelaDeportivaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var foros = await _context.Foros.ToListAsync();
            return View(foros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Foro foro)
        {
            if (ModelState.IsValid)
            {
                //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                /*foro.IdEstudiante = int.Parse(userId);*/ // Asociar el ID del usuario actual
                foro.IdEstudiante = 9;
                _context.Foros.Add(foro);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Publicación creada exitosamente.";
                return RedirectToAction("Index", "Foro");
            }
            TempData["ErrorMessage"] = "No se pudo crear la publicación.";
            return View(foro);
        }

        
    }
}
