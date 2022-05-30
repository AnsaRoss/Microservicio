using MicroservicioMovimientos.DbContexts;
using MicroservicioMovimientos.ModelsView;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioMovimientos.Repository
{
    public class ReporteMovimientos : IReporteMovimientoRepository
    {
        private readonly ApplicationDbContext _context;
        public IConfiguration _configuration { get; set; }

        public ReporteMovimientos(ApplicationDbContext context, IConfiguration _config)
        {
            _context = context;
            _configuration = _config;
        }

        public List<ReporteEstadoMovimientos> GetReporteMovimientos(int clienteId, string fechaInicio, string fechaFin)
        {
            List<ReporteEstadoMovimientos> _Result = new List<ReporteEstadoMovimientos>();
            ReporteEstadoMovimientos _Item;
            string cn = _configuration["ConnectionStrings:CadenaConexion"];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(cn);
            SqlDataReader result;


            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("es-ES");
            DateTime cfechaIni = DateTime.Parse(fechaInicio, cultureinfo);

            DateTime cfechaFin = DateTime.Parse(fechaFin, cultureinfo);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "reporteEstadoCuenta";
                cmd.Parameters.AddWithValue("@fechaInicio", cfechaIni);
                cmd.Parameters.AddWithValue("@fechaFin", cfechaFin);
                cmd.Parameters.AddWithValue("@clienteId", clienteId);
                cmd.Connection.Open();

                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    _Item = new ReporteEstadoMovimientos();

                    _Item.nombre = Convert.ToString(result.IsDBNull(result.GetOrdinal("nombre")) ? 0 : result["nombre"]);
                    _Item.direccion = Convert.ToString(result.IsDBNull(result.GetOrdinal("direccion")) ? "" : result["direccion"]);
                    _Item.estado = Convert.ToString(result.IsDBNull(result.GetOrdinal("estado")) ? "" : result["estado"]);
                    _Item.numeroCuenta = Convert.ToString(result.IsDBNull(result.GetOrdinal("numeroCuenta")) ? "" : result["numeroCuenta"]);
                    _Item.tipoCuenta = Convert.ToString(result.IsDBNull(result.GetOrdinal("tipoCuenta")) ? "" : result["tipoCuenta"]);
                    _Item.debito = Convert.ToString(result.IsDBNull(result.GetOrdinal("debito")) ? "" : result["debito"]);
                    _Item.credito = Convert.ToString(result.IsDBNull(result.GetOrdinal("credito")) ? "" : result["credito"]);
                    _Item.saldo = Convert.ToString(result.IsDBNull(result.GetOrdinal("saldo")) ? "" : result["saldo"]);
                    _Item.saldoInicial = Convert.ToString(result.IsDBNull(result.GetOrdinal("saldoInicial")) ? "" : result["saldoInicial"]);

                    _Result.Add(_Item);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
                result = null;
                _Item = null;
            }
            return _Result;
        }

        //List<ReporteMovimientos> IReporteMovimientoRepository.GetReporteMovimientos(int clienteId, DateTime fechaInicio, DateTime fechaFin)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
