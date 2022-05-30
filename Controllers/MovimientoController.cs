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
    public class MovimientoController : ControllerBase
    {
        private ICuentaRepository _cuentaRepository;
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientoController(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
        }

        // GET: api/<CuentaController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _movimientoRepository.GetMovimientos();
            return new OkObjectResult(products);
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}", Name = "GetMovimientoId")]
        public IActionResult Get(int id)
        {
            var product = _movimientoRepository.GetMovimientoId(id);
            return new OkObjectResult(product);
        }

        // POST api/<CuentaController>
        [HttpPost]
        public IActionResult Post([FromBody] Movimiento movimiento)
        {
            try
            {
                var maximoDebito = 0.0;

                Cuenta cta = new Cuenta();
                IEnumerable<Movimiento> todosMoviemientosCuenta = new List<Movimiento>();
                var suma=0.0;
                todosMoviemientosCuenta = _movimientoRepository.GetMovimientos();//cuenta.cuentaId


                    cta = _cuentaRepository.GetCuentaId(movimiento.cuentaId);
                    suma = cta.saldoInicial;

                if (todosMoviemientosCuenta.Count() != 0)
                {

                    foreach (var item in todosMoviemientosCuenta)
                    {
                        if (item.cuentaId == movimiento.cuentaId)
                        {
                            if (item.tipoMovimiento == "debito")
                            {
                                suma = suma - item.valor;
                                maximoDebito = maximoDebito + item.valor;
                                if (maximoDebito >= 1000 && item.fecha.ToShortDateString()==DateTime.Now.ToShortDateString())
                                {
                                    return Ok("Cupo diario Excedido");
                                }
                                if (suma <= 0)
                                {
                                    return Ok("Saldo no disponible");
                                }
                            }
                            else if (item.tipoMovimiento == "credito")
                            {
                                suma = suma + item.valor;
                                
                            }


                        }
                    }
                }


                double saldo = suma;
                if (movimiento.tipoMovimiento == "debito")
                    saldo = saldo - movimiento.valor;
                else if (movimiento.tipoMovimiento == "credito")
                    saldo = saldo + movimiento.valor;
                movimiento.saldo = saldo;
                using (var scope = new TransactionScope())
                {
                    _movimientoRepository.InsertarMovimiento(movimiento);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = movimiento.id }, movimiento);
                }
            }
            catch (Exception ex)
            {
                Ok("Ha ocurrido una exepcion "+ ex.Message);
                throw;
            }
            
        }

        // PUT api/<CuentaController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Movimiento movimiento)
        {
            if (movimiento != null)
            {
                using (var scope = new TransactionScope())
                {
                    _movimientoRepository.ActualizarMovimiento(movimiento);
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
            _movimientoRepository.EliminarMovimiento(id);
            return new OkResult();
        }
    }
}
