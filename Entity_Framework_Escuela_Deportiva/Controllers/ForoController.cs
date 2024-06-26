using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
                try
                {
                    // Agregar el foro al contexto y guardar los cambios
                    _context.Foros.Add(foro);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Publicación creada exitosamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Manejar otros tipos de excepciones si es necesario
                    TempData["ErrorMessage"] = "Error al crear la publicación: " + ex.Message;
                    return View(foro); // Mostrar la vista Create con los datos ingresados
                }
            }

            // Si hay errores en el ModelState, mostrar mensajes de error
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            TempData["ErrorMessage"] = "No se pudo crear la publicación. Verifique los datos ingresados. Errores: " + string.Join(", ", errors);
            return View(foro);
        }
    }
}