using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class PosValorMetaDataIndicador
    {
        public int? Id { get; set; }
        public int? IdIndicador { get; set; }

        public int IdPosValor { get; set; }

        public int Orden { get; set; }

        [JsonIgnore]
        public string? PosValorMetaData { get; set; }

        [JsonIgnore]
        public string? Descripcion { get; set; }
    }
}
