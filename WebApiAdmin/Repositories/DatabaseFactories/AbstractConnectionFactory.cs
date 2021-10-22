using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories.DatabaseFactories
{
    public abstract class AbstractConnectionFactory : IConnectionFactory
    {
        public abstract DbConnection CreateConnection(string connectionName);

        public DbConnection CreateConnection()
        {
            return CreateConnection("defaultConn");
        }
    }
}
