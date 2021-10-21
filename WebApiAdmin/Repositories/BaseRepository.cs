using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IConnectionFactory connectionFactory;
        public BaseRepository(IConnectionFactory connFacotry) {
            connectionFactory = connFacotry;
        }

        public DbConnection OpenConnection() {
            return connectionFactory.CreateConnection();
        }

        public async Task< bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using(var conn = OpenConnection())
            {
                var list = await conn.QueryAsync<T>("select * from categories");
                return list;
            }
        }

        public async Task<bool> Save(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
