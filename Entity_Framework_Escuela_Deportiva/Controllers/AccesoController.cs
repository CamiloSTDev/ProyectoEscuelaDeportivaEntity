using Microsoft.AspNetCore.Mvc;
using Entity_Framework_Escuela_Deportiva.Data;
using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.EntityFrameworkCore;
using Entity_Framework_Escuela_Deportiva.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;



namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class AccesoController : Controller
    {
        private readonly EscuelaDeportivaContext _DbContext;

        public AccesoController(EscuelaDeportivaContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM modelo)
        {
            if (modelo.Contraseña != modelo.ConfirmarContraseña)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }



            Estudiante usuario = new()
            {
                Nombres = modelo.Nombres,
                Apellidos = modelo.Apellidos,
                Doc = modelo.Doc,
                Telefono = modelo.Telefono,
                Correo = modelo.Correo,
                FechaNac = modelo.FechaNac,
                Contraseña = modelo.Contraseña,
                IdGrupo = modelo.IdGrupo,

            };




            await _DbContext.Estudiantes.AddAsync(usuario);
            await _DbContext.SaveChangesAsync();



            if (usuario.IdUsuario != 0) return RedirectToAction("Login", "Acceso");

            ViewData["Mensaje"] = "No se pudo crear el Usuario, error fatal";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Estudiante? usuario_encontrado = await _DbContext.Estudiantes.
                Where(e =>
                e.Doc == modelo.Doc &&
                e.Contraseña == modelo.Contraseña
                ).FirstOrDefaultAsync();

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Nombres)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }

    }






}
