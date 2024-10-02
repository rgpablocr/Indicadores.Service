using Indicadores.DA.Interface;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class PeriodicidadBL
    {
        public IPeriodicidadDA periodicidadDA;

        public PeriodicidadBL(IPeriodicidadDA periodicidadDA)
        {
            this.periodicidadDA = periodicidadDA;
        }

        public async Task<List<Periodicidad>> ListarPeriodicidad()
        {
            return await periodicidadDA.ListarPeriodicidad();
        }
    }
}
