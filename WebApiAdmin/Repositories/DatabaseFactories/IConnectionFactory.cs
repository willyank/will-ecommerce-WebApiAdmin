using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories.DatabaseFactories
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection(string connectionName);

        IDbConnection CreateConnection();
    }
}
