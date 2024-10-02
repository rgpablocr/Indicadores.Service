using Indicadores.DA.Interface;
using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.BL.Class
{
    public class EstadoBL
    {
        public IEstadoDA estadoDA;

        public EstadoBL(IEstadoDA estadoDA)
        {
            this.estadoDA = estadoDA;
        }

        public async Task<List<Estado>> ListarEstado()
        {
            return await estadoDA.ListarEstado();
        }
    }
}
