using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ECARTemplate.Models;
using ECARTemplate.Data;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net; // Agrega esta línea

namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom", Roles = "Admin")]
    public class UsuariosTIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosTIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsuariosTI
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuariosTI.ToListAsync());
        }

        // GET: UsuariosTI/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTI = await _context.UsuariosTI.FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioTI == null)
            {
                return NotFound();
            }

            return View(usuarioTI);
        }

        // GET: UsuariosTI/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuariosTI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreUsuario,Usuario,RolUsuario,ContrasenaUsuario")] UsuarioTI usuarioTI)
        {
            // Opcional: Validar si el usuario ya existe por 'Usuario' (nombre de login)
            if (await _context.UsuariosTI.AnyAsync(u => u.Usuario == usuarioTI.Usuario))
            {
                ModelState.AddModelError("Usuario", "Ya existe un usuario con este nombre de login.");
            }

            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuarioTI.ContrasenaUsuario);
                usuarioTI.ContrasenaUsuario = hashedPassword;

                _context.Add(usuarioTI);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Usuario '{usuarioTI.NombreUsuario}' creado exitosamente."; // Mensaje de éxito
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Error al crear el usuario. Revise los datos."; // Mensaje de error
            return View(usuarioTI);
        }

        // GET: UsuariosTI/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                return NotFound();
            }
            return View(usuarioTI);
        }

        // POST: UsuariosTI/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreUsuario,Usuario,RolUsuario,ContrasenaUsuario")] UsuarioTI usuarioTI)
        {
            if (id != usuarioTI.Id)
            {
                return NotFound();
            }

            // Opcional: Validar si el nombre de usuario (login) ya existe en otro usuario
            if (await _context.UsuariosTI.AnyAsync(u => u.Usuario == usuarioTI.Usuario && u.Id != usuarioTI.Id))
            {
                ModelState.AddModelError("Usuario", "Ya existe otro usuario con este nombre de login.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioTIExistente = await _context.UsuariosTI.FindAsync(id);

                    if (usuarioTIExistente == null)
                    {
                        return NotFound();
                    }

                    usuarioTIExistente.NombreUsuario = usuarioTI.NombreUsuario;
                    usuarioTIExistente.Usuario = usuarioTI.Usuario;
                    usuarioTIExistente.RolUsuario = usuarioTI.RolUsuario;

                    if (!string.IsNullOrEmpty(usuarioTI.ContrasenaUsuario))
                    {
                        string nuevaContrasenaHasheada = BCrypt.Net.BCrypt.HashPassword(usuarioTI.ContrasenaUsuario);
                        usuarioTIExistente.ContrasenaUsuario = nuevaContrasenaHasheada;
                    }
                    else
                    {
                        // Si la contraseña está vacía, no la actualizamos para preservar la existente.
                        // EF Core no la sobrescribe si no se cambia la propiedad, pero es bueno ser explícito.
                        _context.Entry(usuarioTIExistente).Property(u => u.ContrasenaUsuario).IsModified = false;
                    }

                    _context.Update(usuarioTIExistente);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Usuario '{usuarioTIExistente.NombreUsuario}' actualizado exitosamente."; // Mensaje de éxito
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioTIExists(usuarioTI.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Error al actualizar el usuario. Revise los datos."; // Mensaje de error
            return View(usuarioTI);
        }

        // GET: UsuariosTI/Delete/5
        // Acción para mostrar la vista de confirmación de eliminación
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTI = await _context.UsuariosTI
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioTI == null)
            {
                return NotFound();
            }

            return View(usuarioTI); // Envía el usuario a la vista para confirmar
        }

        // POST: UsuariosTI/Delete/5
        // Acción para ejecutar la eliminación después de la confirmación
        [HttpPost, ActionName("Delete")] // Mapea esta acción al POST de Delete
        [ValidateAntiForgeryToken] // Previene ataques CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioTI = await _context.UsuariosTI.FindAsync(id);

            if (usuarioTI == null)
            {
                // Si el usuario no se encuentra (quizás ya fue eliminado por otro), redirige con un mensaje.
                TempData["ErrorMessage"] = "El usuario que intentó eliminar no fue encontrado.";
                return RedirectToAction(nameof(Index));
            }

            // --- Lógica de Eliminación ---
            _context.UsuariosTI.Remove(usuarioTI); // Marca la entidad para eliminación
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            // --- Fin Lógica de Eliminación ---

            TempData["SuccessMessage"] = $"Usuario '{usuarioTI.NombreUsuario}' eliminado exitosamente."; // Mensaje de éxito
            return RedirectToAction(nameof(Index)); // Redirige de vuelta a la lista
        }


        // GET: UsuariosTI/Inactivar/5 (Confirmación para Inactivar)
        public async Task<IActionResult> Inactivar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                return NotFound();
            }
            // Aquí se asume que tu modelo UsuarioTI tiene una propiedad 'Estado' o 'EsActivo'
            // para manejar la inactivación lógica. Si no, necesitarías agregarla a tu modelo.
            return View(usuarioTI); // Vista de confirmación
        }

        // POST: UsuariosTI/Inactivar/5 (Ejecutar Inactivar)
        [HttpPost, ActionName("Inactivar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InactivarConfirmado(int id)
        {
            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                TempData["ErrorMessage"] = "El usuario que intentó inactivar no fue encontrado.";
                return NotFound(); // O RedirectToAction con error
            }

            // Asumiendo que UsuarioTI tiene una propiedad 'Estado' (string)
            // Si tu modelo tiene una propiedad booleana como 'EsActivo', úsala: usuarioTI.EsActivo = false;
            // O si necesitas un estado más complejo:
            // usuarioTI.Estado = "Inactivo";
            _context.Update(usuarioTI); // Usa Update si solo cambias propiedades del objeto existente
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Usuario '{usuarioTI.NombreUsuario}' inactivado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuariosTI/Activar/5 (Confirmación para Activar)
        public async Task<IActionResult> Activar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                return NotFound();
            }
            // Asumiendo que tu modelo UsuarioTI tiene una propiedad 'Estado' o 'EsActivo'
            return View(usuarioTI); // Vista de confirmación
        }

        // POST: UsuariosTI/Activar/5 (Ejecutar Activar)
        [HttpPost, ActionName("Activar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivarConfirmado(int id)
        {
            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                TempData["ErrorMessage"] = "El usuario que intentó activar no fue encontrado.";
                return NotFound(); // O RedirectToAction con error
            }

            // Asumiendo que UsuarioTI tiene una propiedad 'Estado' (string)
            // Si tu modelo tiene una propiedad booleana como 'EsActivo', úsala: usuarioTI.EsActivo = true;
            // O si necesitas un estado más complejo:
            // usuarioTI.Estado = "Activo";
            _context.Update(usuarioTI);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Usuario '{usuarioTI.NombreUsuario}' activado exitosamente.";
            return RedirectToAction(nameof(Index));
        }


        private bool UsuarioTIExists(int id)
        {
            return _context.UsuariosTI.Any(e => e.Id == id);
        }
    }
}