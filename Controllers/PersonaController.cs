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
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        // GET: api/<clienteController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _personaRepository.GetPersonas();
            return new OkObjectResult(products);
        }

        // GET api/<clienteController>/5
        [HttpGet("{id}", Name = "GetPersonaId")]
        public IActionResult Get(int id)
        {
            var product = _personaRepository.GetPersonaId(id);
            return new OkObjectResult(product);
        }

        // POST api/<clienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            using (var scope = new TransactionScope())
            {
                _personaRepository.InsertarPersona(persona);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = persona.id }, persona);
            }
        }

        // PUT api/<clienteController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Persona persona)
        {
            if (persona != null)
            {
                using (var scope = new TransactionScope())
                {
                    _personaRepository.ActualizarPersona(persona);
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
            _personaRepository.EliminarPersona(id);
            return new OkResult();
        }
    }
}
