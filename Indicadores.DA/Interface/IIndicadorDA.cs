using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Interface
{
    public interface IIndicadorDA
    {
        Task<List<IndicadorOutput>> ListarIndicadores();
        Task<Respuesta<IndicadorOutput>> InsertarIndicador(IndicadorInput indicadorInput);

        Task<List<PosValorMetaDataIndicador>> listarPosValoresIndicador(int idIndicador);

        Task<Respuesta<IndicadorOutput>> EliminarIndicador(int idIndicador);

        Task<Respuesta<IndicadorOutput>> ModificarIndicador(IndicadorInput indicadorInput);

        Task<Respuesta<PosValorMetaDataIndicador>> AsignarPosValorIndicador(PosValorMetaDataIndicador posValorMetaData);

        Task<Respuesta<PosValorMetaDataIndicador>> DesasignarPosValorIndicador(PosValorMetaDataIndicador posValorMetaData);

        Task<bool> ReordenarPosValoresMetaData(PosValorMetaDataIndicador posValorMetaData);

        Task<bool> ReordenarPosValoresMetaDataBorrado(PosValorMetaDataIndicador posValorMetaData);

        Task<Respuesta<PosValorMetaDataIndicador>> CambiarOrdenPosValor(PosValorMetaDataIndicador posValorMetaData);

    }
}
