using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                // Asignar valores automáticos
                foro.IdEscuela = 123456;

                // Obtener el Id del estudiante activo
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out int idEstudiante))
                {
                    foro.IdEstudiante = idEstudiante;
                }
                else
                {
                    // Manejar el caso en el que no se pueda obtener el Id del estudiante
                    TempData["ErrorMessage"] = "No se pudo obtener el Id del estudiante.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Foros.Add(foro);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Publicación creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "No se pudo crear la publicación.";
            return View(foro);
        }
    }
}
