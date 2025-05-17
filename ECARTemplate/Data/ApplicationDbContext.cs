using System;
using System.Collections.Generic;
using System.Text;
using ECARTemplate.Controllers;
using ECARTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace ECARTemplate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioTI> UsuariosTI { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Credencial> Credenciales { get; set; }

    }
}
