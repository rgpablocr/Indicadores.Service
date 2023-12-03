using Indicadores.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Interface
{
    public interface IPeriodicidadDA
    {
        Task<List<Periodicidad>> ListarPeriodicidad();
    }
}
