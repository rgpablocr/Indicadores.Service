using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class PosValorMetaDataIndicadorInput
    {

        public int IdPosValor { get; set; }

        [JsonIgnoreAttribute]
        public int Orden { get; set; }
    }
}
