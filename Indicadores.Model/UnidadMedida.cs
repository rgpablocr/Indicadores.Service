using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class UnidadMedida
    {
        public int IdUnidadMedida { get; set; }

        public string Valor { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }
    }
}
