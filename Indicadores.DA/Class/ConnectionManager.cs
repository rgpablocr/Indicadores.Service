using Indicadores.DA.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Class
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IConfiguration? _configuration;
        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(_configuration, "DB"));
        }

       //   try
       //     {
       //         using var connection = _connectionManager.GetConnection();

       // var result = await connection.QueryAsync<int>(
       //    sql: "usp_GuardarIndicadoresEconomicos",
       //    param: new
       //    {
       //        datosIndicadoresEconomicos.CodIndicadorEconomico,
       //        datosIndicadoresEconomicos.DesFecha,
       //        datosIndicadoresEconomicos.NumValor
       //    },
       //    commandType: System.Data.CommandType.StoredProcedure
       //);

       // response = result.FirstOrDefault();
       //     }
       //     catch (Exception ex)
       //     {

       //         Console.WriteLine("Error: " + ex.Message);
       //     }
    }
}
