using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ECARTemplate.Data;
using ECARTemplate.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom")]
    public class CredencialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CredencialesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Credenciales
        public async Task<IActionResult> Index(
            string codigoEquipoFiltro,
            DateTime? fechaYHoraDesdeFiltro,
            DateTime? fechaYHoraHastaFiltro,
            string codigoUsuarioEcarFiltro,
            string nombreUsuarioFiltro,
            string perfilFiltro,
            string usuarioFiltro,
            string estadoFiltro,
            string usuarioRegistroFiltro)
        {
            var credenciales = _context.Credenciales.AsQueryable();

            // Filtrado por Código de Equipo
            if (!string.IsNullOrEmpty(codigoEquipoFiltro))
            {
                credenciales = credenciales.Where(c => c.CodigoEquipo.Contains(codigoEquipoFiltro));
            }

            // Filtrado por Rango de Fecha y Hora
            if (fechaYHoraDesdeFiltro.HasValue)
            {
                credenciales = credenciales.Where(c => c.FechaYHora >= fechaYHoraDesdeFiltro.Value);
            }
            if (fechaYHoraHastaFiltro.HasValue)
            {
                credenciales = credenciales.Where(c => c.FechaYHora <= fechaYHoraHastaFiltro.Value.AddDays(1).AddSeconds(-1));
            }

            // Filtrado por Código de Usuario Ecar
            if (!string.IsNullOrEmpty(codigoUsuarioEcarFiltro))
            {
                credenciales = credenciales.Where(c => c.CodigoUsuarioEcar.Contains(codigoUsuarioEcarFiltro));
            }

            // Filtrado por Nombre de Usuario
            if (!string.IsNullOrEmpty(nombreUsuarioFiltro))
            {
                credenciales = credenciales.Where(c => c.NombreUsuario.Contains(nombreUsuarioFiltro));
            }

            // Filtrado por Perfil
            if (!string.IsNullOrEmpty(perfilFiltro))
            {
                credenciales = credenciales.Where(c => c.Perfil.Contains(perfilFiltro));
            }

            // Filtrado por Usuario
            if (!string.IsNullOrEmpty(usuarioFiltro))
            {
                credenciales = credenciales.Where(c => c.Usuario.Contains(usuarioFiltro));
            }

            // Filtrado por Estado
            if (!string.IsNullOrEmpty(estadoFiltro))
            {
                credenciales = credenciales.Where(c => c.Estado.Contains(estadoFiltro));
            }

            // Filtrado por Usuario de Registro
            if (!string.IsNullOrEmpty(usuarioRegistroFiltro))
            {
                credenciales = credenciales.Where(c => c.UsuarioRegistro.Contains(usuarioRegistroFiltro));
            }

            return View(await credenciales.ToListAsync());
        }

        // GET: Credenciales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credencial = await _context.Credenciales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credencial == null)
            {
                return NotFound();
            }

            return View(credencial);
        }

        // GET: Credenciales/Create
        public IActionResult Create()
        {
            var credencial = new Credencial
            {
                FechaYHora = DateTime.Now
            };
            return View(credencial);
        }

        // POST: Credenciales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Credencial credencial)
        {
            if (ModelState.IsValid)
            {
                // Verificar si ya existe una credencial con el mismo CodigoEquipo y CodigoUsuarioEcar
                bool existeCredencial = await _context.Credenciales
                    .AnyAsync(c => c.CodigoEquipo == credencial.CodigoEquipo &&
                                   c.CodigoUsuarioEcar == credencial.CodigoUsuarioEcar);

                if (existeCredencial)
                {
                    // Si existe un registro duplicado, agregar un error al ModelState
                    ModelState.AddModelError(string.Empty,
                        $"Ya existe un registro para el usuario {credencial.CodigoUsuarioEcar} en el equipo {credencial.CodigoEquipo}.");
                    return View(credencial);
                }

                _context.Add(credencial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Si el modelo no es válido, vuelve a mostrar el formulario con los errores
            return View(credencial);
        }

        // GET: Credenciales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credencial = await _context.Credenciales.FindAsync(id);
            if (credencial == null)
            {
                return NotFound();
            }
            return View(credencial);
        }

        // POST: Credenciales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoEquipo,FechaYHora,CodigoUsuarioEcar,NombreUsuario,Perfil,Usuario,Contrasena,Estado,UsuarioRegistro")] Credencial credencial) // Cambiado UsuarioTi a UsuarioRegistro
        {
            if (id != credencial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CredencialExists(credencial.Id))
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
            return View(credencial);
        }

        // GET: Credenciales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credencial = await _context.Credenciales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credencial == null)
            {
                return NotFound();
            }

            return View(credencial);
        }

        // POST: Credenciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credencial = await _context.Credenciales.FindAsync(id);
            _context.Credenciales.Remove(credencial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Credenciales/Activar/5
        public async Task<IActionResult> Activar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credencial = await _context.Credenciales.FindAsync(id);
            if (credencial == null)
            {
                return NotFound();
            }

            credencial.Estado = "Activo";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Credenciales/Desactivar/5
        public async Task<IActionResult> Desactivar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credencial = await _context.Credenciales.FindAsync(id);
            if (credencial == null)
            {
                return NotFound();
            }

            credencial.Estado = "Inactivo";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CredencialExists(int id)
        {
            return _context.Credenciales.Any(e => e.Id == id);
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerDatosUsuario(string codigoEmpleadoEcar)
        {
            if (string.IsNullOrEmpty(codigoEmpleadoEcar))
            {
                return Json(new { success = false, message = "El Código de Usuario es requerido." });
            }

            var empleado = await _context.Empleados
                .Where(e => e.CodigoEmpleadoEcar == codigoEmpleadoEcar)
                .Select(e => new
                {
                    e.CodigoEmpleadoEcar,
                    e.NombreEmpleado,
                    Usuario = e.FirmaBpm // Asignamos FirmaBpm al campo Usuario
                })
                .FirstOrDefaultAsync();

            if (empleado == null)
            {
                return Json(new { success = false, message = "No se encontró ningún empleado con ese código." });
            }

            return Json(new { success = true, data = empleado });
        }

        // GET: Credenciales/Clonar/5
        public async Task<IActionResult> Clonar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credencial = await _context.Credenciales.FindAsync(id);
            if (credencial == null)
            {
                return NotFound();
            }

            // Creamos un nuevo objeto Credencial con datos del original
            var credencialClon = new Credencial
            {
                // No copiamos el Id, se generará uno nuevo
                CodigoEquipo = "", // Este campo estará vacío para que el usuario lo llene
                FechaYHora = DateTime.Now, // Actualizamos la fecha a la actual
                CodigoUsuarioEcar = credencial.CodigoUsuarioEcar,
                NombreUsuario = credencial.NombreUsuario,
                Perfil = credencial.Perfil,
                Usuario = credencial.Usuario,
                Contrasena = credencial.Contrasena,
                Estado = credencial.Estado,
                UsuarioRegistro = User?.Identity?.Name // Usuario actual
            };

            // Pasamos el ID original a la vista mediante ViewBag para referencia
            ViewBag.CredencialOriginalId = id;

            return View("Clonar", credencialClon);
        }

        // POST: Credenciales/GuardarClon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarClon(Credencial credencial)
        {
            if (ModelState.IsValid)
            {
                // Verificar si ya existe una credencial con el mismo CodigoEquipo y CodigoUsuarioEcar
                bool existeCredencial = await _context.Credenciales
                    .AnyAsync(c => c.CodigoEquipo == credencial.CodigoEquipo &&
                                  c.CodigoUsuarioEcar == credencial.CodigoUsuarioEcar);

                if (existeCredencial)
                {
                    // Si existe un registro duplicado, agregar un error al ModelState
                    ModelState.AddModelError(string.Empty,
                        $"Ya existe un registro para el usuario {credencial.CodigoUsuarioEcar} en el equipo {credencial.CodigoEquipo}.");
                    return View("Clonar", credencial);
                }

                // Aseguramos que estamos creando un nuevo registro
                credencial.Id = 0;
                credencial.FechaYHora = DateTime.Now;

                _context.Add(credencial);
                await _context.SaveChangesAsync();

                // Redirigir al índice con un mensaje de éxito
                TempData["SuccessMessage"] = "La credencial se ha clonado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, vuelve a mostrar el formulario con los errores
            return View("Clonar", credencial);
        }


    }
}