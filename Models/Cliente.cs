using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public String contrasenia { get; set; }
        public String estado { get; set; }
        public int personaId { get; set; }
        [ForeignKey("personaId")]
        public virtual Persona personas { get; set; }
    }
}
