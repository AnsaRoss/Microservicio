using MicroservicioMovimientos.Models;
using MicroservicioMovimientos.ModelsView;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cliente> tb_cliente { get; set; }
        public DbSet<Cuenta> tb_cuenta { get; set; }
        public DbSet<Movimiento> tb_movimiento { get; set; }
        public DbSet<Persona> tb_persona { get; set; }
        //public DbSet<ReporteMovimientos> reporteMovimientos { get; set; }
    }
}
