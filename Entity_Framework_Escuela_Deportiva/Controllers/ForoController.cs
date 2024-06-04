using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create(Foro foro, int usuarioId)
        {
            if (ModelState.IsValid)
            {
                foro.IdEstudiante = usuarioId; // Asociar el ID del usuario actual
                _context.Foros.Add(foro);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Publicación creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "No se pudo crear la publicación.";
            return View(foro);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var foro = await _context.Foros.FindAsync(id);
            if (foro == null)
            {
                return NotFound();
            }
            return View(foro);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Foro foro)
        {
            if (id != foro.IdForo)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foro);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Publicación actualizada exitosamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["ErrorMessage"] = "No se pudo actualizar la publicación.";
                    return View(foro);
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "No se pudo actualizar la publicación.";
            return View(foro);
        }
    }
}
