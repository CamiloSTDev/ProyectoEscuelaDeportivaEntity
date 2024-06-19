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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Foro foro)
        {
            if (ModelState.IsValid)
            {
                // Asignar valores automáticamente
                foro.IdEscuela = 123456;
                foro.IdEstudiante = 9; // Set the ID of the user
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
