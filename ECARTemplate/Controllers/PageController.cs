using Microsoft.AspNetCore.Mvc;
using ECARTemplate.Data;
using ECARTemplate.Models;
using ECARTemplate.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ECARTemplate.Controllers
{
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Custom"); // "Custom" debe coincidir con tu esquema de autenticaci�n configurado en Startup.cs
            return RedirectToAction("Login"); // Redirige a la p�gina de inicio de sesi�n despu�s de cerrar sesi�n
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.UsuariosTI.FirstOrDefaultAsync(u => u.Usuario == model.Usuario);

                if (usuario != null && BCrypt.Net.BCrypt.Verify(model.ContrasenaUsuario, usuario.ContrasenaUsuario))
                {
                    // Autenticaci�n exitosa
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), // Identificador �nico del usuario
                        new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                        new Claim(ClaimTypes.Role, usuario.RolUsuario), // Si deseas usar roles basados en esta propiedad
                        new Claim("Usuario", usuario.Usuario),
                        // Agrega otras claims del usuario si es necesario
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Custom");
                    var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                    {
                        IsPersistent = model.Recordarme,
                        // Otras propiedades de autenticaci�n
                    };

                    await HttpContext.SignInAsync("Custom", new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home"); // Redirige a la p�gina principal
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "C�digo de usuario o contrase�a inv�lidos.");
                }
            }

            return View(model);
        }

   
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) // Usa RegisterViewModel
        {
            if (ModelState.IsValid)
            {
                // Hash de la contrase�a antes de guardarla
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.ContrasenaUsuario);

                var nuevoUsuario = new UsuarioTI
                {
                    NombreUsuario = model.NombreUsuario,
                    Usuario = model.Usuario,
                    ContrasenaUsuario = hashedPassword, // Guarda la contrase�a hasheada
                    RolUsuario = model.RolUsuario, // Asigna el rol
                    // Otros campos que necesites asignar
                };

                _context.UsuariosTI.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                // Redirigir a la p�gina de confirmaci�n o a donde sea apropiado
                return RedirectToAction("Confirmation"); // Asumiendo que tienes una acci�n Confirmation
            }
            // Si el modelo no es v�lido, vuelve a la vista con los errores
            return View(model);
        }
        public IActionResult Search() => View();
    }
}
