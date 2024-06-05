using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly EscuelaDeportivaContext _context;
        private readonly AsistenciaService _asistenciaService;

        public AsistenciaController(EscuelaDeportivaContext context)
        {
            _context = context;
            _asistenciaService = new AsistenciaService(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public class DocumentoModel
        {
            [Required]
            [Display(Name = "Número de Documento")]
            public int Documento { get; set; }
        }

        public class AsistenciaService
        {
            private readonly EscuelaDeportivaContext _context;

            public AsistenciaService(EscuelaDeportivaContext context)
            {
                _context = context;
            }
            public Estudiante ConsultarAsistencia(int documento)
            {              
                    var estudiante = _context.Estudiantes
                      .Where(e => e.Doc == documento)
                      .FirstOrDefault();
                    return estudiante;               
            }
        }

        [HttpPost]
        public IActionResult ConsultarAsistencia(DocumentoModel model)
        {
            if (ModelState.IsValid)
            {
                var asistenciaService = new AsistenciaService(_context);
                var estudiante = asistenciaService.ConsultarAsistencia(model.Documento);

                if (estudiante != null)
                {
                    ViewBag.Estudiantes = new[] { estudiante };
                    ViewBag.TotalAsis = estudiante.AsisTotal;
                    return View("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se encontró la asistencia para el documento ingresado.");
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
    }
}
