using Dapper;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Class
{
    public class PeriodicidadDA : IPeriodicidadDA
    {
        private readonly ConnectionManager _connectionManager;

        public PeriodicidadDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Periodicidad>> ListarPeriodicidad()
        {
            List<Periodicidad> periodicidad = new List<Periodicidad>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<Periodicidad>(
                    sql: "usp_ListarPeriodicidad",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                periodicidad = result.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return periodicidad;
        }
    }
}
