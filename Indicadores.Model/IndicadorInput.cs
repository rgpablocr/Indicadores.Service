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
        public int CuentaCatalogoIndicador { get; set; }

        public int EstadoIndicador { get; set; }
        public int PeriodicidadIndicador { get; set; }

        public int UnidadMedidaIndicador { get; set; }

        public List<PosValorMetaDataIndicadorInput> PosValoresList { get; set; }

        public string? PosValores { get; set; }

    }
}
