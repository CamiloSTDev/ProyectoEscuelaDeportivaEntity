using Microsoft.AspNetCore.Mvc;
using Entity_Framework_Escuela_Deportiva.Data;
using Entity_Framework_Escuela_Deportiva.Models;
using Entity_Framework_Escuela_Deportiva.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class ProfileController : Controller
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
        }

        private readonly UserManager<IdentityUser> _editContext;
        public ProfileController(UserManager<IdentityUser> editContext)
        {
            _editContext = editContext;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile()
        {
            var usuario_activo = await _editContext.GetUserAsync(User);
            //if (usuario_activo == null) 
            //{
            //    return NotFound();
            //}

            var model = new UsuarioEditVM
            {
                Nombres = usuario_activo.UserName!,
                Correo = usuario_activo.Email!,
                Telefono = usuario_activo.PhoneNumber!,
                Contraseña = usuario_activo.PasswordHash!,
                ConfirmarContraseña = usuario_activo.PasswordHash!,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UsuarioEditVM model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var usuario_activo = await _editContext.GetUserAsync(User);
            if (usuario_activo == null)
            {
                return NotFound();
            }

            usuario_activo.UserName = model.Nombres;
            usuario_activo.Email = model.Correo;
            usuario_activo.PhoneNumber = model.Telefono;
            usuario_activo.PasswordHash = model.Contraseña;
            usuario_activo.PasswordHash = model.ConfirmarContraseña;

            await _editContext.UpdateAsync(usuario_activo);

            return RedirectToAction(nameof(Index));
        }
    }
}
