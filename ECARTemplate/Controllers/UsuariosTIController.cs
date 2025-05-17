using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ECARTemplate.Models;
using ECARTemplate.Data; // Asegúrate de usar el namespace correcto de tu contexto
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net; // Agrega esta línea

namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom")]
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
            if (ModelState.IsValid)
            {
                // Hash de la contraseña antes de guardarla
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuarioTI.ContrasenaUsuario);
                usuarioTI.ContrasenaUsuario = hashedPassword; // Guarda el hash en la entidad

                _context.Add(usuarioTI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener el usuario existente de la base de datos
                    var usuarioTIExistente = await _context.UsuariosTI.FindAsync(id);

                    if (usuarioTIExistente == null)
                    {
                        return NotFound();
                    }

                    // Actualizar propiedades (excluyendo la contraseña)
                    usuarioTIExistente.NombreUsuario = usuarioTI.NombreUsuario;
                    usuarioTIExistente.Usuario = usuarioTI.Usuario;
                    usuarioTIExistente.RolUsuario = usuarioTI.RolUsuario;

                    // Manejar la contraseña SÓLO si se ha proporcionado una nueva contraseña
                    if (!string.IsNullOrEmpty(usuarioTI.ContrasenaUsuario))
                    {
                        // Hash de la nueva contraseña
                        string nuevaContrasenaHasheada = BCrypt.Net.BCrypt.HashPassword(usuarioTI.ContrasenaUsuario);
                        usuarioTIExistente.ContrasenaUsuario = nuevaContrasenaHasheada;
                    }
                    _context.Update(usuarioTIExistente);
                    await _context.SaveChangesAsync();
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
            return View(usuarioTI);
        }

        // GET: UsuariosTI/Delete/5
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

            return View(usuarioTI);
        }

        // POST: UsuariosTI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            _context.UsuariosTI.Remove(usuarioTI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuariosTI/Inactivar/5
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
            // Aquí podrías pasar información adicional a la vista de confirmación
            return View(usuarioTI);
        }

        // POST: UsuariosTI/Inactivar/5
        [HttpPost, ActionName("Inactivar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InactivarConfirmado(int id)
        {
            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                return NotFound();
            }
            // Aquí implementa la lógica para "inactivar" al usuarioTI.
            // Podrías agregar una propiedad 'EsActivo' al modelo UsuariosTI
            // y simplemente cambiar su valor a false.
            // Ejemplo (asumiendo que tienes una propiedad EsActivo):
            // usuarioTI.EsActivo = false;
            //usuarioTI.Estado = "Inactivo"; //Esto ya no es necesario
            _context.Update(usuarioTI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuariosTI/Activar/5
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
            // Aquí podrías pasar información adicional a la vista de confirmación
            return View(usuarioTI);
        }

        // POST: UsuariosTI/Activar/5
        [HttpPost, ActionName("Activar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivarConfirmado(int id)
        {
            var usuarioTI = await _context.UsuariosTI.FindAsync(id);
            if (usuarioTI == null)
            {
                return NotFound();
            }
            // Aquí implementa la lógica para "activar" al usuarioTI.
            // Ejemplo (asumiendo que tienes una propiedad EsActivo):
            // usuarioTI.EsActivo = true;
            //usuarioTI.Estado = "Activo"; //Esto ya no es necesario
            _context.Update(usuarioTI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioTIExists(int id)
        {
            return _context.UsuariosTI.Any(e => e.Id == id);
        }
    }
}
