﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.Model
{
    public class PosValorMetaDataIndicador
    {
        public int? IdIndicador { get; set; }

        public int IdPosValor { get; set; }

        public int Orden { get; set; }

        public string? PosValorMetaData { get; set; }

        public string? Descripcion { get; set; }
    }
}
