using Dapper;
using Indicadores.DA.Class;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Interface
{
    public interface IPosValorDA
    {
        Task<List<PosValor>> ListarPosValores();
        Task<List<PosValor>> ListarPosValor(int idPosValor);
        Task<Respuesta<PosValor>> InsertarPosValor(PosValor PosValor);
        Task<Respuesta<PosValor>> ModificarPosValor(PosValor PosValor);
        Task<Respuesta<PosValor>> EliminarPosValor(int idPosValor);

    }
}
