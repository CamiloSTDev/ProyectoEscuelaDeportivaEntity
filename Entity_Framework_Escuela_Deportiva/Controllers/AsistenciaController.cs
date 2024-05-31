using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class AsistenciaController : Controller
        
    {

        private readonly ILogger<AsistenciaController> _logger;
        private readonly EscuelaDeportivaContext _dbContext;

        public AsistenciaController(ILogger<AsistenciaController> logger, EscuelaDeportivaContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ConsultarAsistencia()
        {
            try
            {

                var estudiantes = _dbContext.Estudiantes.ToList();
                var horarios = _dbContext.Horarios.ToList();


                ViewData["Estudiantes"] = estudiantes;
                ViewData["Horarios"] = horarios;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar la asistencia");
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]

public IActionResult Consultar(int documentNumber)

{

    try

    {

        var estudiante = _dbContext.Estudiantes.FirstOrDefault(e => e.Doc == documentNumber);


        if (estudiante!= null)

        {

                    var asistencia = estudiante.AsisTotal;


                    if (asistencia!= null)

            {

                var model = new AsistenciaViewModel

                {

                    Estudiante = estudiante,

                    Asistencia = asistencia

                };


                return View("Consultar", model);

            }

            else

            {

                TempData["Error"] = "No se encontró asistencia para el estudiante";

                return RedirectToAction("Index");

            }

        }

        else

        {

            TempData["Error"] = "No se encontró estudiante con el número de documento ingresado";

            return RedirectToAction("Index");

        }

    }

    catch (Exception ex)

    {

        _logger.LogError(ex, "Error al consultar la asistencia");

        return RedirectToAction("Error", "Home");

    }

}
    }
}
