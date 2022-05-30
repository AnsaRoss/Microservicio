using MicroservicioMovimientos.Models;
using MicroservicioMovimientos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroservicioMovimientos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/<clienteController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _clienteRepository.GetClientes();
            return new OkObjectResult(products);
        }

        // GET api/<clienteController>/5
        [HttpGet("{id}", Name = "GetClienteId")]
        public IActionResult Get(int id)
        {
            var product = _clienteRepository.GetClienteId(id);
            return new OkObjectResult(product);
        }

        // POST api/<clienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            using (var scope = new TransactionScope())
            {
                _clienteRepository.InsertarCliente(cliente);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = cliente.id }, cliente);
            }
        }

        // PUT api/<clienteController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                using (var scope = new TransactionScope())
                {
                    _clienteRepository.ActualizarCliente(cliente);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<clienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteRepository.EliminarCliente(id);
            return new OkResult();
        }
    }
}
