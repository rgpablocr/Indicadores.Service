using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class MetaData
    {
        public int IdMetaData { get; set; }

        public string Prefijo { get; set; }

        public string? Descripcion { get; set; }
    }
}
