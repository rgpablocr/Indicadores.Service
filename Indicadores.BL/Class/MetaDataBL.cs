using Indicadores.DA.Interface;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class MetaDataBL
    {

        public IMetaDataDA metaDataDA;

        public MetaDataBL(IMetaDataDA metaDataDA)
        {
            this.metaDataDA = metaDataDA;
        }
        public async Task<List<MetaData>> ListarMetadata()
        {
            return await this.metaDataDA.ListarMetadata();
        }

        public async Task<Respuesta<MetaData>> ConsultarMetadata(int idMetaData)
        {
            return await metaDataDA.ConsultarMetadata(idMetaData);
        }
        public async Task<Respuesta<MetaData>> InsertarMetadata(MetaData metaData)
        {
            return await metaDataDA.InsertarMetadata(metaData);
        }

        public async Task<Respuesta<MetaData>> EliminarMetadata(int idMetaData)
        {
            return await metaDataDA.EliminarMetadata(idMetaData);
        }

        public async Task<Respuesta<MetaData>> ModificarMetadata(MetaData metaData)
        {
            return await metaDataDA.ModificarMetadata(metaData);
        }
    }
}
