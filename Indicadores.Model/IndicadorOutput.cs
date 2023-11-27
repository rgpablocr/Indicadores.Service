using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class IndicadorOutput
    {
        public int IdIndicador { get; set; }

        public int IdCuentaCatalogo { get; set; }

        public int IdEstado { get; set; }
        public int IdPeriodicidad { get; set; }

        public int? IdUnidadMedida { get; set; }

        public string CuentaCatalogo { get; set; }

        public string Estado { get; set; }
        public string Periodicidad { get; set; }

        public string UnidadMedida { get; set; }
    }
}
