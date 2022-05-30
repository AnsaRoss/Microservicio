using MicroservicioMovimientos.DbContexts;
using MicroservicioMovimientos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ActualizarPersona(Persona Persona)
        {
            _context.Entry(Persona).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarPersona(int id)
        {
            var product = _context.tb_persona.Find(id);
            _context.tb_persona.Remove(product);
            _context.SaveChanges();
        }

        public Persona GetPersonaId(int id)
        {
            return _context.tb_persona.Find(id);
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _context.tb_persona.ToList();
        }



        public void InsertarPersona(Persona Persona)
        {
            _context.Add(Persona);
            _context.SaveChanges();
        }
    }
}
