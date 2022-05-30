using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.ModelsView
{
    public class ReporteEstadoMovimientos
    {
        //[Key]
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String estado { get; set; }
        public String numeroCuenta { get; set; }
        public String tipoCuenta { get; set; }
        public String debito { get; set; }
        public String credito { get; set; }
        public String saldo { get; set; }
        public String saldoInicial { get; set; }
    }
}
