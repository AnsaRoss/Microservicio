using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Models
{
    public class Movimiento
    {
        [Key]
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public String tipoMovimiento { get; set; }
        public double valor { get; set; }
        public double saldo { get; set; }
        public int cuentaId { get; set; }
        [ForeignKey("cuentaId")]
        public virtual Cuenta cuentas { get; set; }
    }
}
