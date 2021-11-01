using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.DatabaseFactories;

namespace WebApiAdmin.Repositories
{
    

    public class PostgresConnectionFactory : AbstractConnectionFactory
    {
        private IConfiguration _config;


        public PostgresConnectionFactory(IConfiguration configuration)
        {
            _config = configuration;
        }

        public override IDbConnection CreateConnection(string connectionName)
        {
            return new NpgsqlConnection(_config.GetConnectionString(connectionName));
        }

    }
}
