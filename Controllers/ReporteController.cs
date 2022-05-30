using MicroservicioMovimientos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroservicioMovimientos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteMovimientoRepository _reporteRepository;

        public ReporteController(IReporteMovimientoRepository cuentaRepository)
        {
            _reporteRepository = cuentaRepository;
        }

        // GET: api/<ReporteController>
        [HttpGet("{personaId}/{fechaInicio}/{fechaFin}", Name = "GetReporteMovimientos")]
        public IActionResult Get(int personaId, string fechaInicio, string fechaFin)
        {
            var products = _reporteRepository.GetReporteMovimientos(personaId, fechaInicio, fechaFin);
            return new OkObjectResult(products);
            //return Ok("");
        }

        // GET api/<ReporteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}
