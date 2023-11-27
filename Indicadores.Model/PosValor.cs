using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class PosValor
    {
        public int IdPosValor { get; set; }

        public int IdMetaData { get; set; }
        public string PosValorMetaData { get; set; }
        public string? Descripcion { get; set; }
    }
}
