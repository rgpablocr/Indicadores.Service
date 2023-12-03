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
    public interface IUnidadDeMedidaDA
    {
        Task<List<UnidadMedida>> ListarUnidadMedida();
        Task<Respuesta<UnidadMedida>> InsertarUnidadMedida(UnidadMedida unidadMedida);
        Task<Respuesta<UnidadMedida>> ModificarUnidadMedida(UnidadMedida unidadMedida);
        Task<Respuesta<UnidadMedida>> EliminarUnidadMedida(int idUnidadMedida);

    }
}
