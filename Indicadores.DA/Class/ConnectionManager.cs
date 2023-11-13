using Indicadores.DA.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicadores.DA.Class
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IConfiguration? _configuration;
        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(_configuration, "DB"));
        }
    }
}
