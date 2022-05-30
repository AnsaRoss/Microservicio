using MicroservicioMovimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetPersonas();
        Persona GetPersonaId(int id);
        void InsertarPersona(Persona Persona);
        void EliminarPersona(int id);
        void ActualizarPersona(Persona Persona);
    }
}
