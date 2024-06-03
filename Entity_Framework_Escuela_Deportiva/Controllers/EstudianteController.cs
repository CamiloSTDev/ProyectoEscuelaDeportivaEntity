using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly EscuelaDeportivaContext _context;

        public EstudianteController(EscuelaDeportivaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(int id, [Bind("IdUsuario,Nombres,Apellidos,Doc,Telefono,FechaNac,Correo")] Estudiante estudiante)
        {
            if (id != estudiante.IdUsuario)
            {
                return BadRequest();
            }

            var estudianteToUpdate = await _context.Estudiantes.FindAsync(id);
            if (estudianteToUpdate == null)
            {
                return NotFound();
            }

            estudianteToUpdate.Nombres = estudiante.Nombres;
            estudianteToUpdate.Apellidos = estudiante.Apellidos;
            estudianteToUpdate.Doc = estudiante.Doc;
            estudianteToUpdate.Telefono = estudiante.Telefono;
            estudianteToUpdate.FechaNac = estudiante.FechaNac;
            estudianteToUpdate.Correo = estudiante.Correo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Profile), new { id = estudiante.IdUsuario });
    }
}
