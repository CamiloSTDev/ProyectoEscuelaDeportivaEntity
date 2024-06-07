using Entity_Framework_Escuela_Deportiva.Data;
using Entity_Framework_Escuela_Deportiva.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entity_Framework_Escuela_Deportiva.Models;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class ProfileController : Controller
    {
        
            private EscuelaDeportivaContext _editcontext;

            public ProfileController(EscuelaDeportivaContext editcontext)
            {
                _editcontext = editcontext;
            }

            [HttpGet]
            [Authorize]
            public IActionResult EditProfile()
            {
                var IdUsuario = IdUsuario.Identity.GetUserId();
                var Usuario = _editcontext.Estudiantes.SingleOrDefault(u => u.IdUsuario == IdUsuario);

                return View(Usuario);
            }

            [HttpPost]
            [Authorize]
            public IActionResult EditProfile(Estudiante modelos)
            {
                var IdUsuario = IdUsuario.Identity.GetUserId();
                var Usuario = _editcontext.Estudiantes.SingleOrDefault(u => u.IdUsuario == IdUsuario);

                if (!ModelState.IsValid)
                {
                    return View(modelos);
                }

                Usuario.Doc = modelos.Doc;
                Usuario.Nombres = modelos.Nombres;
                // Agrega aquí cualquier otro campo que quieras permitir que se actualice

                _editcontext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        

    }
}
