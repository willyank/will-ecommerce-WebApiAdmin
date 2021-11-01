using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories.DatabaseFactories
{
    public abstract class AbstractConnectionFactory : IConnectionFactory
    {
        public abstract IDbConnection CreateConnection(string connectionName);

        public IDbConnection CreateConnection()
        {
            return CreateConnection("defaultConn");
        }
    }
}
