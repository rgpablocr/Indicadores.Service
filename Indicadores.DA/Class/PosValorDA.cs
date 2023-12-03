using Indicadores.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Indicadores.DA.Interface;

namespace Indicadores.DA.Class
{
    public class PosValorDA : IPosValorDA
    {


        private readonly ConnectionManager _connectionManager;

        public PosValorDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }


        public async Task<List<PosValor>> ListarPosValores()
        {
            List<PosValor> UnidadDeMedida = new List<PosValor>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<PosValor>(
                    sql: "usp_MostrarPosValor",
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


        public async Task<List<PosValor>> ListarPosValor(int idPosValor)
        {
            List<PosValor> UnidadDeMedida = new List<PosValor>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<PosValor>(
                    sql: "usp_MostrarPosValor",
                    param: new {idPosValor},
                    commandType: System.Data.CommandType.StoredProcedure
                );

                    UnidadDeMedida = result.ToList();
                

            }
            catch (Exception)
            {
                throw;
            }

            return UnidadDeMedida;
        }


        public async Task<Respuesta<PosValor>> InsertarPosValor(PosValor PosValor)
        {


            Respuesta<PosValor> respuesta = new Respuesta<PosValor>();

            try
            {

                char primerLetra = Convert.ToChar( PosValor.PosValorMetaData.Substring(0, 1));
                char segundaLetra = Convert.ToChar(PosValor.PosValorMetaData.Substring(1, 1));
                char tercerLetra = Convert.ToChar(PosValor.PosValorMetaData.Substring(2, 1));

                if (!char.IsLetter(primerLetra) || !char.IsLetter(segundaLetra) || tercerLetra != '_')
                {
                    respuesta.Mensaje = "El PosValor de metadata debe estar compuesto por dos letras, seguidas por un guión bajo";
                    return respuesta;
                }


                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdMetaData", PosValor.IdMetaData, DbType.String);
                parameters.Add("@PosValorMetaData", PosValor.PosValorMetaData, DbType.String);
                parameters.Add("@Descripcion", PosValor.Descripcion, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<PosValor>>(
                   sql: "usp_InsertarPosValor",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new PosValor
                    {
                        IdMetaData = PosValor.IdMetaData,
                        Descripcion = PosValor.Descripcion,
                        PosValorMetaData = PosValor.PosValorMetaData,
                    });
                }



            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        public async Task<Respuesta<PosValor>> ModificarPosValor(PosValor PosValor)
        {


            Respuesta<PosValor> respuesta = new Respuesta<PosValor>();

            try
            {
                char primerLetra = Convert.ToChar(PosValor.PosValorMetaData.Substring(0, 1));
                char segundaLetra = Convert.ToChar(PosValor.PosValorMetaData.Substring(1, 1));
                char tercerLetra = Convert.ToChar(PosValor.PosValorMetaData.Substring(2, 1));

                if (!char.IsLetter(primerLetra) || !char.IsLetter(segundaLetra) || tercerLetra != '_')
                {
                    respuesta.Mensaje = "El PosValor de metadata debe estar compuesto por dos letras, seguidas por un guión bajo";
                    return respuesta;
                }
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@idPosValor", PosValor.IdPosValor, DbType.String);
                parameters.Add("@IdMetaData", PosValor.IdMetaData, DbType.String);
                parameters.Add("@PosValorMetaData", PosValor.PosValorMetaData, DbType.String);
                parameters.Add("@Descripcion", PosValor.Descripcion, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<PosValor>>(
                   sql: "usp_ModificarPosValor",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new PosValor
                    {
                        IdMetaData = PosValor.IdMetaData,
                        Descripcion = PosValor.Descripcion,
                        PosValorMetaData = PosValor.PosValorMetaData,
                    });
                }



            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        public async Task<Respuesta<PosValor>> EliminarPosValor(int idPosValor)
        {



            Respuesta<PosValor> respuesta = new Respuesta<PosValor>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@idPosValor", idPosValor, DbType.Int32);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<PosValor>>(
                   sql: "usp_EliminarPosValor",
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
