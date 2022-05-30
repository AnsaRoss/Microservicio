using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Models
{
    public class Cuenta
    {
        [Key]
        public int id { get; set; }
        public String numeroCuenta { get; set; }
        public String tipoCuenta { get; set; }
        public double saldoInicial { get; set; }
        public string estado { get; set; }
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        public virtual Cliente clientes { get; set; }
    }
}
