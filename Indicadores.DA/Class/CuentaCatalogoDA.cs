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
    public class CuentaCatalogoDA : ICuentaCatalogoDA
    {
        private readonly ConnectionManager _connectionManager;

        public CuentaCatalogoDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<CuentaCatalogo>> ListarCuentaCatalogo()
        {
            List<CuentaCatalogo> cuentaCatalogo = new List<CuentaCatalogo>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<CuentaCatalogo>(
                    sql: "usp_ListarCuentaCatalogo",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                cuentaCatalogo = result.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return cuentaCatalogo;
        }

    }
}
