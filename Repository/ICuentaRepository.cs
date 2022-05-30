using MicroservicioMovimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public interface ICuentaRepository
    {
        IEnumerable<Cuenta> GetCuentas();
        Cuenta GetCuentaId(int id);
        void InsertarCuenta(Cuenta cuenta);
        void EliminarCuenta(int id);
        void ActualizarCuenta(Cuenta cuenta);
    }
}
