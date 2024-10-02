﻿
using Indicadores.DA.Interface;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class IndicadorBL 
    {

        public IIndicadorDA indicadorDA;

        public IndicadorBL(IIndicadorDA indicadorDA)
        { 
            this.indicadorDA = indicadorDA;
        }

        public async Task<List<IndicadorOutput>> listarIndicadores()
        {
            return await indicadorDA.ListarIndicadores();
        }

        public async Task<Respuesta<IndicadorOutput>> InsertarIndicador(IndicadorInput indicadorInput)
        {
            return await indicadorDA.InsertarIndicador(indicadorInput);
        }
        public async Task<Respuesta<IndicadorOutput>> EliminarIndicador(int idIndicador)
        {
            return await indicadorDA.EliminarIndicador(idIndicador);
        }

        public async Task<Respuesta<IndicadorOutput>> ModificarIndicador(IndicadorInput indicadorInput)
        {
            return await indicadorDA.ModificarIndicador(indicadorInput);
        }

        public async Task<Respuesta<PosValorMetaDataIndicador>> AsignarPosValorIndicador(PosValorMetaDataIndicador posValorMetaData)
        {
            return await indicadorDA.AsignarPosValorIndicador(posValorMetaData);
        }

        public async Task<Respuesta<PosValorMetaDataIndicador>> DesasignarPosValorIndicador(PosValorMetaDataIndicador posValorMetaData)
        {
            return await indicadorDA.DesasignarPosValorIndicador(posValorMetaData);
        }

    }
}
