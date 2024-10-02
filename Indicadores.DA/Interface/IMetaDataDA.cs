using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Interface
{
    public interface IMetaDataDA
    {
        Task<List<MetaData>> ListarMetadata();

        Task<Respuesta<MetaData>> ConsultarMetadata(int idMetaData);
        Task<Respuesta<MetaData>> InsertarMetadata(MetaData metaData);

        Task<Respuesta<MetaData>> EliminarMetadata(int idMetaData);

        Task<Respuesta<MetaData>> ModificarMetadata(MetaData metaData);
    }
}
