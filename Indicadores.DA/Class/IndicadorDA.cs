using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indicadores.DA.Interface;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Xml;
using Indicadores.DA.Extensions;
using Newtonsoft.Json;

namespace Indicadores.DA.Class
{
    public class IndicadorDA : IIndicadorDA
    {
        private readonly ConnectionManager _connectionManager;

        public IndicadorDA(IConfiguration configuration) {
            _connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<IndicadorOutput>> ListarIndicadores()
        {
            List<IndicadorOutput> indicador = new List<IndicadorOutput>();
            try
            {
                
                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<IndicadorOutput>(
                    sql: "usp_ListarIndicadores",
                    commandType: System.Data.CommandType.StoredProcedure
                );   

                if(result != null)
                {
                    indicador = result.ToList();

                    for(int i = 0; i < indicador.Count; i++)
                    {
                        indicador[i].PosValores = await listarPosValoresIndicador((int)indicador[i].IdIndicador);
                    }
                    
                }

            }
                catch (Exception)
			{

				throw;
			}

            return indicador;
        }

        public async Task<List<PosValorMetaDataIndicador>> listarPosValoresIndicador(int idIndicador)
        {
            List<PosValorMetaDataIndicador> posvalores = new List<PosValorMetaDataIndicador>();
            try
            {

                using var connection = _connectionManager.GetConnection();

                var result = await connection.QueryAsync<PosValorMetaDataIndicador>(
                    sql: "usp_ListarPosValoresIndicador",
                    param: new { idIndicador},
                    commandType: System.Data.CommandType.StoredProcedure
                );

                posvalores = result.ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return posvalores;
        }


        public async Task<Respuesta<IndicadorOutput>> InsertarIndicador(IndicadorInput indicadorInput)
        {
            XmlConverter xmlConverter = new XmlConverter();
            for (int i = 0; i < indicadorInput.PosValoresList.Count; i++)
            {
                indicadorInput.PosValoresList[i].Orden = i;
            }

            indicadorInput.PosValores = xmlConverter.PosValorToXML(indicadorInput.PosValoresList);
            Respuesta<IndicadorOutput> respuesta = new Respuesta<IndicadorOutput>();
          
          
            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@CuentaCatalogoIndicador", indicadorInput.CuentaCatalogoIndicador, DbType.String);
                parameters.Add("@UnidadMedidaIndicador", indicadorInput.UnidadMedidaIndicador, DbType.String);
                parameters.Add("@EstadoIndicador", indicadorInput.EstadoIndicador, DbType.String);
                parameters.Add("@PeriodicidadIndicador", indicadorInput.PeriodicidadIndicador, DbType.String);
                parameters.Add("@PosValores", indicadorInput.PosValores, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<IndicadorOutput>>(
                   sql: "usp_InsertarIndicador",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if(respuesta.Estado == 0 ) {
                    respuesta.Lista.Add(new IndicadorOutput
                    {
                        IdCuentaCatalogo = indicadorInput.CuentaCatalogoIndicador,
                        IdUnidadMedida = indicadorInput.UnidadMedidaIndicador,
                        IdEstado = indicadorInput.EstadoIndicador,
                        IdPeriodicidad = indicadorInput.PeriodicidadIndicador
                    });
                    respuesta.Lista[0].PosValores = new List<PosValorMetaDataIndicador>();
                    foreach (var posValor  in indicadorInput.PosValoresList)
                    {
                        respuesta.Lista[0].PosValores.Add(new PosValorMetaDataIndicador
                        {
                            IdPosValor = posValor.IdPosValor,
                            Orden = posValor.Orden
                        }); 
                    }
                }            
              
                
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        public async Task<Respuesta<IndicadorOutput>> ModificarIndicador(IndicadorInput indicadorInput)
        {       
            Respuesta<IndicadorOutput> respuesta = new Respuesta<IndicadorOutput>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdIndicador", indicadorInput.IdIndicador, DbType.String);
                parameters.Add("@CuentaCatalogo", indicadorInput.CuentaCatalogoIndicador, DbType.String);
                parameters.Add("@UnidadMedida", indicadorInput.UnidadMedidaIndicador, DbType.String);
                parameters.Add("@Estado", indicadorInput.EstadoIndicador, DbType.String);
                parameters.Add("@Periodicidad", indicadorInput.PeriodicidadIndicador, DbType.String);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<IndicadorOutput>>(
                   sql: "usp_ModificarIndicador",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if (respuesta.Estado == 0)
                {
                    respuesta.Lista.Add(new IndicadorOutput
                    {
                        IdCuentaCatalogo = indicadorInput.CuentaCatalogoIndicador,
                        IdUnidadMedida = indicadorInput.UnidadMedidaIndicador,
                        IdEstado = indicadorInput.EstadoIndicador,
                        IdPeriodicidad = indicadorInput.PeriodicidadIndicador
                    }); 
                }


            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }



        public async Task<Respuesta<PosValorMetaDataIndicador>> AsignarPosValorIndicador(PosValorMetaDataIndicador posValorMetaData)
        {
            Respuesta<PosValorMetaDataIndicador> respuesta = new Respuesta<PosValorMetaDataIndicador>();
            bool reordenamiento = false;

            try
            {
                reordenamiento = await ReordenarPosValoresMetaData(posValorMetaData);

                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdIndicador", posValorMetaData.IdIndicador, DbType.Int32);
                parameters.Add("@IdPosValor", posValorMetaData.IdPosValor, DbType.Int32);
                parameters.Add("@Orden", posValorMetaData.Orden, DbType.Int32);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<PosValorMetaDataIndicador>>(
                   sql: "usp_AsignarPosValorIndicador",
                   param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure
               );

                respuesta = result.FirstOrDefault();

                if ( !reordenamiento)
                {
                    respuesta.Estado = 1;
                    respuesta.Mensaje = "Error al reordenar la lista. Intentelo de nuevo";
                }
               
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        public async Task<Respuesta<PosValorMetaDataIndicador>> DesasignarPosValorIndicador(PosValorMetaDataIndicador posValorMetaData)
        {
            Respuesta<PosValorMetaDataIndicador> respuesta = new Respuesta<PosValorMetaDataIndicador>();
            bool reordenamiento = false;

            try
            {

                reordenamiento = await ReordenarPosValoresMetaDataBorrado(posValorMetaData);
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdIndicador", posValorMetaData.IdIndicador, DbType.Int32);
                parameters.Add("@Id", posValorMetaData.Id, DbType.Int32);
                parameters.Add("@Orden", posValorMetaData.Orden, DbType.Int32);//se le pasa para ordenar data

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<PosValorMetaDataIndicador>>(
                   sql: "usp_DesasignarPosValorIndicador",
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

        public async Task<Respuesta<PosValorMetaDataIndicador>> CambiarOrdenPosValor(PosValorMetaDataIndicador posValorMetaData)
        {
            Respuesta<PosValorMetaDataIndicador> respuesta = new Respuesta<PosValorMetaDataIndicador>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", posValorMetaData.Id, DbType.Int32);
                parameters.Add("@Orden", posValorMetaData.Orden, DbType.Int32);

                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<PosValorMetaDataIndicador>>(
                   sql: "usp_OrdenarPosValoresMetaData",
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

        public async Task<bool> ReordenarPosValoresMetaData(PosValorMetaDataIndicador posValorMetaData)
        {
            Respuesta<PosValorMetaDataIndicador> respuesta = new Respuesta<PosValorMetaDataIndicador>();
            List<PosValorMetaDataIndicador> posvalores = new List<PosValorMetaDataIndicador>();
            posvalores = await listarPosValoresIndicador((int)posValorMetaData.IdIndicador);
            //PRIMERO METER NUEVO VALOR EN POSICION CORRESP.
            if(posvalores.Any(ord => ord.Orden == posValorMetaData.Orden))
            {
                //posvalores.Last().Orden = posValorMetaData.Orden; //le asigno el orden deseado
                //await CambiarOrdenPosValor(posvalores.Last());//ingreso el ultimo en el orden que se desea

                for (int i = posValorMetaData.Orden; i < posvalores.Count; i++)
                {
                    posvalores[i].Orden = i+1;
                    await CambiarOrdenPosValor(posvalores[i]);
                }
            }

            return true;
         
        }

        public async Task<bool> ReordenarPosValoresMetaDataBorrado(PosValorMetaDataIndicador posValorMetaData)
        {
            Respuesta<PosValorMetaDataIndicador> respuesta = new Respuesta<PosValorMetaDataIndicador>();
            List<PosValorMetaDataIndicador> posvalores = new List<PosValorMetaDataIndicador>();
            posvalores = await listarPosValoresIndicador((int)posValorMetaData.IdIndicador);
            if (posvalores.Last().Orden != posValorMetaData.Orden)
            {

                for (int i = posvalores.Count - 1; i > posValorMetaData.Orden; i--)
                {
                    posvalores[i].Orden = i - 1;
                    await CambiarOrdenPosValor(posvalores[i]);
                }
            }

            return true;

        }


        public async Task<Respuesta<IndicadorOutput>> EliminarIndicador(int idIndicador)
        {

            Respuesta<IndicadorOutput> respuesta = new Respuesta<IndicadorOutput>();

            try
            {
                using var connection = _connectionManager.GetConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@IdIndicador", idIndicador, DbType.Int32);
              
                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var result = await connection.QueryAsync<Respuesta<IndicadorOutput>>(
                   sql: "usp_EliminarIndicador",
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
