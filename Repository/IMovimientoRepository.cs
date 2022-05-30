using MicroservicioMovimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public interface IMovimientoRepository
    {
        IEnumerable<Movimiento> GetMovimientos();
        Movimiento GetMovimientoId(int id);
        //IEnumerable<Movimiento> GetMovimientosId(int id);
        void InsertarMovimiento(Movimiento movimiento);
        void EliminarMovimiento(int Id);
        void ActualizarMovimiento(Movimiento movimiento);
    }
}
