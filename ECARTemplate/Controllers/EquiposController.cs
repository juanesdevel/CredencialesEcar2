﻿using Microsoft.AspNetCore.Mvc;
using ECARTemplate.Data; // Importa tu ApplicationDbContext
using ECARTemplate.Models; // Importa tus modelos
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ECARTemplate.Controllers
{
    [Authorize(AuthenticationSchemes = "Custom")]

    public class EquiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public string CodigoEquipo { get; private set; }

        public EquiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Simplified member access for LINQ queries to address IDE0037
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var equipos = _context.Equipos.AsQueryable(); // Simplify member access

            if (!string.IsNullOrEmpty(searchString))
            {
                equipos = equipos.Where(e =>
                    e.CodigoEquipo.Contains(searchString) ||
                    e.NombreEquipo.Contains(searchString));
            }

            return View(await equipos.ToListAsync());
        }


        // GET: Equipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoEquipo,Fecha,NombreEquipo,Sede,Area,SubArea,Nota,Estado,UsuarioTiRegistro")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Equipos.AnyAsync(e => e.CodigoEquipo == equipo.CodigoEquipo))
                {
                    ModelState.AddModelError("CodigoEquipo", "Ya existe un equipo con este código.");
                    return View(equipo);
                }

                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Si ModelState no es válido, volver a mostrar el formulario con los errores
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoEquipo,Fecha,NombreEquipo,Sede,Area,SubArea,Nota,Estado,UsuarioTiRegistro")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si ya existe otro equipo con el mismo CodigoEquipo
                    if (await _context.Equipos.AnyAsync(e => e.CodigoEquipo == equipo.CodigoEquipo && e.Id != equipo.Id))
                    {
                        ModelState.AddModelError("CodigoEquipo", "Ya existe otro equipo con este código.");
                        return View(equipo); // Volver a mostrar el formulario con el error
                    }

                    equipo.FechaModificacion = DateTime.Now;
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Mover fuera del bloque try-catch
            }
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }

        // GET: Equipos/Activar/5
        public async Task<IActionResult> Activar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            equipo.Estado = "Activo"; // O el estado que definas para "activo"
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Equipos/Inactivar/5
        public async Task<IActionResult> Inactivar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            equipo.Estado = "Inactivo"; // O el estado que definas para "inactivo"
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Buscar(string term)
        {
    
            var equiposFiltrados = await _context.Equipos
                .Where(e => e.CodigoEquipo.Contains(term) || e.NombreEquipo.Contains(term))
                .ToListAsync();

            return Json(equiposFiltrados);
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerCodigoPorReferencia(string referencia)
        {
            if (string.IsNullOrEmpty(referencia))
            {
                return Json(new { existe = false, mensaje = "Debe proporcionar un código de equipo." });
            }

            // Buscar el equipo por código
            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(e => e.CodigoEquipo == referencia);

            if (equipo != null)
            {
                // Si el equipo existe, devolver sus datos
                return Json(new
                {
                    existe = true,
                    codigoEquipo = equipo.CodigoEquipo,
                    nombreEquipo = equipo.NombreEquipo
                });
            }
            else
            {
                // Si no existe, devolver un mensaje
                return Json(new { existe = false, mensaje = "No se encontró ningún equipo con el código especificado." });
            }
        }

    }
}
