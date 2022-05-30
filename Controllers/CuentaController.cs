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
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        // GET: api/<CuentaController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _cuentaRepository.GetCuentas();
            return new OkObjectResult(products);
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}", Name = "GetCuentaId")]
        public IActionResult Get(int id)
        {
            var product = _cuentaRepository.GetCuentaId(id);
            return new OkObjectResult(product);
        }

        // POST api/<CuentaController>
        [HttpPost]
        public IActionResult Post([FromBody] Cuenta cuenta)
        {
            using (var scope = new TransactionScope())
            {
                _cuentaRepository.InsertarCuenta(cuenta);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = cuenta.id }, cuenta);
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Cuenta cuenta)
        {
            if (cuenta != null)
            {
                using (var scope = new TransactionScope())
                {
                    _cuentaRepository.ActualizarCuenta(cuenta);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cuentaRepository.EliminarCuenta(id);
            return new OkResult();
        }
    }
}
