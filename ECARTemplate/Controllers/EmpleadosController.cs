
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ECARTemplate.Models;
using ECARTemplate.Data;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ECARTemplate.Controllers
    {
        [Authorize(AuthenticationSchemes = "Custom")]
        public class EmpleadosController : Controller
        {
            private readonly ApplicationDbContext _context;

            public EmpleadosController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> ObtenerDatosUsuario(string codigoEmpleadoEcar)
            {
                try
                {
                    // Log para depuración
                    Console.WriteLine($"Buscando empleado con código: {codigoEmpleadoEcar}");

                    if (string.IsNullOrEmpty(codigoEmpleadoEcar))
                    {
                        return Json(new { success = false, message = "El Código de Empleado es requerido." });
                    }

                    var empleado = await _context.Empleados
                        .Where(e => e.CodigoEmpleadoEcar == codigoEmpleadoEcar)
                        .Select(e => new
                        {
                            codigoUsuarioEcar = e.CodigoEmpleadoEcar, // Cambiamos a camelCase para consistencia JSON
                            nombreEmpleado = e.NombreEmpleado,        // Cambiamos a camelCase para consistencia JSON
                            usuario = e.FirmaBpm                     // Cambiamos a camelCase para consistencia JSON
                        })
                        .FirstOrDefaultAsync();

                    if (empleado == null)
                    {
                        Console.WriteLine("No se encontró empleado con ese código");
                        return Json(new { success = false, message = "No se encontró ningún empleado con ese código." });
                    }

                    Console.WriteLine($"Empleado encontrado: {empleado.nombreEmpleado}");
                    return Json(new { success = true, data = empleado });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al buscar empleado: {ex.Message}");
                    return Json(new { success = false, message = $"Error: {ex.Message}" });
                }
            }


            // GET: Empleado
            public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var empleados = from e in _context.Empleados
                            select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(e =>
                    e.CodigoEmpleadoEcar.Contains(searchString) ||
                    e.NombreEmpleado.Contains(searchString));
            }

            return View(await empleados.ToListAsync());
        }

        // GET: Empleado/BuscarEmpleados
        public async Task<IActionResult> BuscarEmpleados(string term)
        {
            var empleadosFiltrados = await _context.Empleados
                .Where(e => e.CodigoEmpleadoEcar.Contains(term) || e.NombreEmpleado.Contains(term))
                .ToListAsync();

            return Json(empleadosFiltrados);
        }


        // GET: Empleados
        //  public async Task<IActionResult> Index()
        // {
        // return View(await _context.Empleados.ToListAsync()); // Cambiado a Empleados
        // }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(
                _context.Empleados, // Cambiado a Empleados
                m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoEmpleadoEcar,Fecha,NombreEmpleado,Cargo,Area,SubArea,Nota,Estado,UsuarioRegistro,FechaModificacion,FIrmaBpm")] Empleado empleado) // Cambiado a Empleado
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id); // Cambiado a Empleados
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoEmpleadoEcar,Fecha,NombreEmpleado,Cargo,Area,SubArea,Nota,Estado,UsuarioRegistro,FechaModificacion,FIrmaBpm")] Empleado empleado) // Cambiado a Empleado
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(id))
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
            return View(empleado);
        }

        // GET: Empleados/Activar/5
        public async Task<IActionResult> Activar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id); // Cambiado a Empleados
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Estado = "Activo";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Empleados/Desactivar/5
        public async Task<IActionResult> Desactivar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);  // Cambiado a Empleados
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Estado = "Inactivo";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id) // Cambiado a EmpleadoExists
        {
            return _context.Empleados.Any(e => e.Id == id); // Cambiado a Empleados
        }
    }
}
