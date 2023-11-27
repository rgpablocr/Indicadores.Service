using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class IndicadorInput
    {
        public int IdIndicador { get; set; }

        public int IdCuentaCatalogo { get; set; }

        public int IdEstado { get; set; }
        public int IdPeriodicidad { get; set; }

        public int? IdUnidadMedida { get; set; }
    }
}
