using Indicadores.DA.Class;
using Indicadores.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Indicadores.DA.Extensions
{
    public class XmlConverter
    {
        public string JsonToXML(string jsonResult)
        {
            
             return JsonConvert.DeserializeXNode(jsonResult, "Root").ToString();
        }

        public string PosValorToXML(List<PosValorMetaDataIndicadorInput> posValores)
        {
            var xml = new XElement("PosValores",
                from posValor in posValores
                select new XElement("PosValor", 
                new XElement("id", posValor.IdPosValor),
                new XElement("orden", posValor.Orden)
             ));

            return xml.ToString();


        }
    }
}
