using Dapper;
using Indicadores.DA.Extensions;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Class
{
    public class UnidadDeMedidaDA : IUnidadDeMedidaDA
    {
        private readonly ConnectionManager _connectionManager;

        public UnidadDeMedidaDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }


        public async Task<List<UnidadMedida>> ListarUnidadMedida()
        {
            List<UnidadMedida> UnidadDeMedida = new List<UnidadMedida>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<UnidadMedida>(
                    sql: "usp_MostrarUnidadesDeMedida",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                if (result != null)
                {
                    UnidadDeMedida = result.ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return UnidadDeMedida;
        }


        public async Task<Respuesta<UnidadMedida>> InsertarUnidadMedida(UnidadMedida unidadMedida)
        {


            Respuesta<UnidadMedida> respuesta = new Respuesta<UnidadMedida>();
            

            try
            {
             

                if (!unidadMedida.Valor.All(char.IsLetter))
                {
                    respuesta.Mensaje = "El valor de la unidad debe contener unicamente letras";
                    return respuesta;
                }

                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Valor", unidadMedida.Valor, DbType.String);
                parameters.Add("@Descripcion", unidadMedida.Descripcion, DbType.String);
                parameters.Add("@Status", unidadMedida.Estado, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<UnidadMedida>>(
                   sql: "usp_InsertarUnidadDeMedida",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new UnidadMedida
                    {
                        Valor = unidadMedida.Valor,
                        Descripcion = unidadMedida.Descripcion,
                        Estado = unidadMedida.Estado,
                    });
                }



            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        public async Task<Respuesta<UnidadMedida>> ModificarUnidadMedida(UnidadMedida unidadMedida)
        {


            Respuesta<UnidadMedida> respuesta = new Respuesta<UnidadMedida>();

            try
            {
                if (!unidadMedida.Valor.All(char.IsLetter))
                {
                    respuesta.Mensaje = "El valor de la unidad debe contener unicamente letras";
                    return respuesta;
                }
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@idUnidadMedida", unidadMedida.IdUnidadMedida, DbType.String);
                parameters.Add("@Valor", unidadMedida.Valor, DbType.String);
                parameters.Add("@Descripcion", unidadMedida.Descripcion, DbType.String);
                parameters.Add("@Status", unidadMedida.Estado, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<UnidadMedida>>(
                   sql: "usp_ModificarUnidadDeMedida",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new UnidadMedida
                    {
                        Valor = unidadMedida.Valor,
                        Descripcion = unidadMedida.Descripcion,
                        Estado = unidadMedida.Estado,
                    });
                }



            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        public async Task<Respuesta<UnidadMedida>> EliminarUnidadMedida(int idUnidadMedida)
        {



            Respuesta<UnidadMedida> respuesta = new Respuesta<UnidadMedida>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@idUnidadMedida", idUnidadMedida, DbType.Int32);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<UnidadMedida>>(
                   sql: "usp_EliminarUnidadDeMedida",
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
