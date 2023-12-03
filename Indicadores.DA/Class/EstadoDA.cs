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
    public class EstadoDA : IEstadoDA
    {
        private readonly ConnectionManager _connectionManager;

        public EstadoDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Estado>> ListarEstado()
        {
            List<Estado> estados = new List<Estado>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<Estado>(
                    sql: "usp_ListarEstado",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                estados = result.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return estados;
        }
    }
}
