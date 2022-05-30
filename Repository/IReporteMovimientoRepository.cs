using MicroservicioMovimientos.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public interface IReporteMovimientoRepository
    {
        List<ReporteEstadoMovimientos> GetReporteMovimientos(int clienteId, string fechaInicio, string fechaFin);
    }
}
