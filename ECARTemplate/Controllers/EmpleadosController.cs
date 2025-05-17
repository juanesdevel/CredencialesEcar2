using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ECARTemplate.Models;
using ECARTemplate.Data;
using Microsoft.AspNetCore.Authorization;


namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom")]

    public class EmpleadosController : Controller // Este controlador podría renombrarse a EmpleadosController
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
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
