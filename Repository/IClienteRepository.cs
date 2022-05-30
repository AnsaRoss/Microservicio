using MicroservicioMovimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClienteId(int id);
        void InsertarCliente(Cliente cliente);
        void EliminarCliente(int id);
        void ActualizarCliente(Cliente cliente);
    }
}
