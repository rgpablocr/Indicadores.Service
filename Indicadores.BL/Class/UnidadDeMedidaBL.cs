using Dapper;
using Indicadores.DA.Class;
using Indicadores.DA.Interface;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class UnidadDeMedidaBL
    {

        public IUnidadDeMedidaDA unidadDA;

        public UnidadDeMedidaBL(IUnidadDeMedidaDA unidadDA)
        {
            this.unidadDA = unidadDA;
        }


        public async Task<List<UnidadMedida>> ListarUnidadMedida()
        {
           return await unidadDA.ListarUnidadMedida();
        }


        public async Task<Respuesta<UnidadMedida>> InsertarUnidadMedida(UnidadMedida unidadMedida)
        {

            return await unidadDA.InsertarUnidadMedida(unidadMedida);
       
        }


        public async Task<Respuesta<UnidadMedida>> ModificarUnidadMedida(UnidadMedida unidadMedida)
        {

            return await unidadDA.ModificarUnidadMedida(unidadMedida);
        
        }


        public async Task<Respuesta<UnidadMedida>> EliminarUnidadMedida(int idUnidadMedida)
        {

            return await unidadDA.EliminarUnidadMedida(idUnidadMedida);

          

        }




    }
}
