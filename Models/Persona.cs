using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Models
{
    public class Persona
    {
        [Key]
        public int id { get; set; }
        public String nombre { get; set; }
        public String genero { get; set; }
        public int edad { get; set; }
        public String identificacion { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
    }
}
