using MicroservicioMovimientos.DbContexts;
using MicroservicioMovimientos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly ApplicationDbContext _context;
        public CuentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ActualizarCuenta(Cuenta Cuenta)
        {
            _context.Entry(Cuenta).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarCuenta(int id)
        {
            var product = _context.tb_cuenta.Find(id);
            _context.tb_cuenta.Remove(product);
            _context.SaveChanges();
        }

        public Cuenta GetCuentaId(int id)
        {
            return _context.tb_cuenta.Find(id);
        }

        public IEnumerable<Cuenta> GetCuentas()
        {
            return _context.tb_cuenta.ToList();
        }


        public void InsertarCuenta(Cuenta Cuenta)
        {
            _context.Add(Cuenta);
            _context.SaveChanges();
        }
    }
}