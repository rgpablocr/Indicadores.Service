using Indicadores.DA.Interface;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class CuentaCatalogoBL
    {
        public ICuentaCatalogoDA cuentaCatalogoDA;

        public CuentaCatalogoBL(ICuentaCatalogoDA cuentaCatalogoDA)
        {
            this.cuentaCatalogoDA = cuentaCatalogoDA;
        }

        public async Task<List<CuentaCatalogo>> ListarCuentaCatalogo()
        {
            return await cuentaCatalogoDA.ListarCuentaCatalogo();
        }
    }
}
