using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories
{
    public interface IConnectionFactory
    {
        DbConnection CreateConnection(string connectionName);

        DbConnection CreateConnection();
    }

    public class ConnectionFactory : IConnectionFactory
    {
        private IConfiguration _config;


        public ConnectionFactory(IConfiguration configuration)
        {
            _config = configuration;
        }

        public DbConnection CreateConnection(string connectionName)
        {
            return new NpgsqlConnection(_config.GetConnectionString(connectionName));
        }

        public DbConnection CreateConnection()
        {
            return CreateConnection("defaultConn");
        }
    }
}
