using MicroservicioMovimientos.DbContexts;
using MicroservicioMovimientos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ActualizarCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var product = _context.tb_cliente.Find(id);
            _context.tb_cliente.Remove(product);
            _context.SaveChanges();
        }

        public Cliente GetClienteId(int id)
        {
            return _context.tb_cliente.Find(id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.tb_cliente.ToList();
        }



        public void InsertarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }
    }
}
