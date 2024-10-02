using Dapper;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Indicadores.Model.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Class
{
    public class TokenUsuarioDA : ITokenUsuarioDA
    {

        private readonly ConnectionManager _connectionManager;

        public TokenUsuarioDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }
        public async Task<Respuesta<TokenUsuario>> AutenticarUsuario(TokenUsuario tokenUsuario)
        {

            Respuesta<TokenUsuario> respuesta = new Respuesta<TokenUsuario>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Usuario", tokenUsuario.Usuario, DbType.String);
                parameters.Add("@Clave", tokenUsuario.Clave, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<TokenUsuario>>(
                   sql: "usp_LoginUsuario",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }
    }
}
