using Dapper;
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
    public class MetaDataDA : IMetaDataDA
    {
        private readonly ConnectionManager _connectionManager;

        public MetaDataDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<MetaData>> ListarMetadata()
        {
            List<MetaData> metaData = new List<MetaData>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<MetaData>(
                    sql: "usp_ListarMetadata",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                metaData = result.ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return metaData;
        }

        public async Task<Respuesta<MetaData>> InsertarMetadata(MetaData metaData)
        {
            Respuesta<MetaData> respuesta = new Respuesta<MetaData>();
            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Prefijo", metaData.Prefijo, DbType.String);
                parameters.Add("@Descripcion", metaData.Descripcion, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<MetaData>>(
                   sql: "usp_CrearMetadata",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new MetaData
                    {
                        Prefijo = metaData.Prefijo,
                        Descripcion = metaData.Descripcion
                    }); 
                }

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        public async Task<Respuesta<MetaData>> ModificarMetadata(MetaData metaData)
        {
            Respuesta<MetaData> respuesta = new Respuesta<MetaData>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdMetaData", metaData.IdMetaData, DbType.Int32);
                parameters.Add("@Prefijo", metaData.Prefijo, DbType.String);
                parameters.Add("@Descripcion", metaData.Descripcion, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<MetaData>>(
                   sql: "usp_EditarMetadata",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new MetaData
                    {
                       IdMetaData = metaData.IdMetaData,
                       Descripcion = metaData.Descripcion,
                       Prefijo = metaData.Prefijo
                    });
                }


            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        public async Task<Respuesta<MetaData>> EliminarMetadata(int idMetaData)
        {

            Respuesta<MetaData> respuesta = new Respuesta<MetaData>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdMetaData", idMetaData, DbType.Int32);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<MetaData>>(
                   sql: "usp_EliminaMetadata",
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

        public async Task<Respuesta<MetaData>> ConsultarMetadata(int idMetaData)
        {

            Respuesta<MetaData> respuesta = new Respuesta<MetaData>();
             MetaData item = new MetaData();
            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdMetaData", idMetaData, DbType.Int32);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                // var result = await connection.QueryAsync<Respuesta<MetaData>>(
                //    sql: "usp_ConsultarMetadata",
                //    param: parameters,
                //    commandType: System.Data.CommandType.StoredProcedure
                //);

               
                using (var multi = await connection.QueryMultipleAsync("usp_ConsultarMetadata", parameters))
                {
                     var metaData = await multi.ReadAsync<MetaData>();
                     var respuestaSp = await multi.ReadAsync<Respuesta<MetaData>>();

                    respuesta.Mensaje = respuestaSp.FirstOrDefault().Mensaje;
                    respuesta.Estado = respuestaSp.FirstOrDefault().Estado;

                    if (respuesta.Estado == 0)
                    {
                        respuesta.Lista = metaData.ToList();
                    }
                  
                }

               
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


    }
}
