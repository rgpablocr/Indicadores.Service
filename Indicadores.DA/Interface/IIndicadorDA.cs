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

    }
}
