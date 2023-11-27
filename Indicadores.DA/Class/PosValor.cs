using Indicadores.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Class
{
    public class PosValor
    {
        //Estado = 1 exito
        //Estado = 0 exito

        //public Respuesta insertarPosValor(PosValor posValor)
        //{
        //    //try
        //    //{
        //    //    this.sqlConnection.ConnectionString = this.ObtenerConnectionString();
        //    //    this.sqlConnection.Open();
        //    //    this.sqlCommand = new SqlCommand(query, this.sqlConnection);
        //    //    this.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    //    foreach (var item in data)
        //    //    {
        //    //        sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
        //    //    }

        //    //    sqlCommand.Parameters.Add("@INDICADOR", SqlDbType.Int);
        //    //    sqlCommand.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50);
        //    //    sqlCommand.Parameters["@INDICADOR"].Direction = ParameterDirection.Output;
        //    //    sqlCommand.Parameters["@MENSAJE"].Direction = ParameterDirection.Output;

        //    //    await sqlCommand.ExecuteNonQueryAsync();
        //    //    RespuestaSP = new Respuesta
        //    //    {
        //    //        Estado = Convert.ToInt32(sqlCommand.Parameters["@Estado"].Value),
        //    //        Mensaje = sqlCommand.Parameters["@Mensaje"].Value.ToString()
        //    //    };
        //    //}
        //}

    }
}
