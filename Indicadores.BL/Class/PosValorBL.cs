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
    public class PosValorBL
    {

        public IPosValorDA posValorDA;

        public PosValorBL( IPosValorDA posValorDA)
        {
            this.posValorDA = posValorDA;   
        }

        public async Task<List<PosValor>> ListarPosValores()
        {
            return await posValorDA.ListarPosValores();
        }


        public async Task<List<PosValor>> ListarPosValor(int idPosValor)
        {
            return await posValorDA.ListarPosValor(idPosValor);
        }


        public async Task<Respuesta<PosValor>> InsertarPosValor(PosValor posValor)
        {
            return await posValorDA.InsertarPosValor(posValor);
        }


        public async Task<Respuesta<PosValor>> ModificarPosValor(PosValor posValor)
        {
            return await posValorDA.ModificarPosValor(posValor);
        }


        public async Task<Respuesta<PosValor>> EliminarPosValor(int idPosValor)
        {
            return await posValorDA.EliminarPosValor(idPosValor);
        }


    }
}
