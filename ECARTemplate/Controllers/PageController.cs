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
            await HttpContext.SignOutAsync("Custom"); // "Custom" debe coincidir con tu esquema de autenticación configurado en Startup.cs
            return RedirectToAction("Login"); // Redirige a la página de inicio de sesión después de cerrar sesión
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
                    // Autenticación exitosa
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), // Identificador único del usuario
                        new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                        new Claim(ClaimTypes.Role, usuario.RolUsuario), // Si deseas usar roles basados en esta propiedad
                        new Claim("Usuario", usuario.Usuario),
                        // Agrega otras claims del usuario si es necesario
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Custom");
                    var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                    {
                        IsPersistent = model.Recordarme,
                        // Otras propiedades de autenticación
                    };

                    await HttpContext.SignInAsync("Custom", new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home"); // Redirige a la página principal
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Código de usuario o contraseña inválidos.");
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
                // Hash de la contraseña antes de guardarla
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.ContrasenaUsuario);

                var nuevoUsuario = new UsuarioTI
                {
                    NombreUsuario = model.NombreUsuario,
                    Usuario = model.Usuario,
                    ContrasenaUsuario = hashedPassword, // Guarda la contraseña hasheada
                    RolUsuario = model.RolUsuario, // Asigna el rol
                    // Otros campos que necesites asignar
                };

                _context.UsuariosTI.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                // Redirigir a la página de confirmación o a donde sea apropiado
                return RedirectToAction("Confirmation"); // Asumiendo que tienes una acción Confirmation
            }
            // Si el modelo no es válido, vuelve a la vista con los errores
            return View(model);
        }
        public IActionResult Search() => View();
    }
}
