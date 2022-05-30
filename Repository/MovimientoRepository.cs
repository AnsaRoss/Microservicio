using MicroservicioMovimientos.DbContexts;
using MicroservicioMovimientos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public class MovimientoRepository:IMovimientoRepository
    {
        private readonly ApplicationDbContext _context;
        public MovimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ActualizarMovimiento(Movimiento movimiento)
        {
            _context.Entry(movimiento).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarMovimiento(int Id)
        {
            var product = _context.tb_movimiento.Find(Id);
            _context.tb_movimiento.Remove(product);
            _context.SaveChanges();
        }

        public Movimiento GetMovimientoId(int id)
        {
            return _context.tb_movimiento.Find(id);
        }

        public IEnumerable<Movimiento> GetMovimientos()
        {
            return _context.tb_movimiento.ToList();
        }

        //public IEnumerable<Movimiento> GetMovimientosId(int id)
        //{
        //    return _context.tb_movimiento.Find(id).ToList();
        //}

        public void InsertarMovimiento(Movimiento movimiento)
        {
            _context.Add(movimiento);
            _context.SaveChanges();
        }
    }
}
