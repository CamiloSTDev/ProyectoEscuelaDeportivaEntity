
using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class HorarioController : Controller
    {
        private readonly EscuelaDeportivaContext _context;


        
        
        public HorarioController(EscuelaDeportivaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTrainingSchedules()

        {

            var lista = await _context.Horarios.ToListAsync();

            var eventos = new { lista };


            // Crear un archivo en la ruta especificada

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "horarios.json");


            var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

            using (var stream = System.IO.File.Create(filePath))

            {

                await JsonSerializer.SerializeAsync(stream, eventos, jsonSerializerOptions);

            }


            // Devolver un objeto IActionResult que indica que el archivo se ha creado correctamente
            return Json(eventos);
            //return Content("Archivo horarios.json creado correctamente", "text/plain");

        }

        //public static List<HorarioController> ConsultarHorario()
        //{
        //    List<HorarioController> lista = new List<HorarioController>();
        //    SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Horario"));
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {

        //    }
        //}

    }


}
