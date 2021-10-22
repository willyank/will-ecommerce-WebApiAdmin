using Dapper;
using EcommerceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.DatabaseFactories;

namespace WebApiAdmin.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly IConnectionFactory connectionFactory;
        public BaseRepository(IConnectionFactory connFacotry)
        {
            connectionFactory = connFacotry;
        }

        public DbConnection OpenConnection()
        {
            return connectionFactory.CreateConnection();
        }

        protected string TableName
        {
            get
            {
                var attributes = typeof(T).GetCustomAttributes(typeof(TableAttribute), true);
                var tableAnnotation = attributes.First() as TableAttribute;

                return tableAnnotation.Name;
            }
        }


        private string GetInsertSql()
        {
            var sql = $"insert into {TableName} ({{0}}) values ({{1}}) RETURNING id";

            var fields = typeof(T).GetProperties().Where(w => w.Name != "Id").Select(s => s.Name);
            var fieldsName = string.Join(",", fields);
            var fieldsParam = string.Join(",", fields.Select(field => $"@{field}"));

            return string.Format(sql, fieldsName, fieldsParam);
        }


        public async Task<int> Delete(long id)
        {
            using (var conn = OpenConnection())
            {
                var totalDeleted = await conn.ExecuteAsync($"delete from {TableName} where id = @id", param: new { id });
                return totalDeleted;
            }
        }

        public async Task<T> Get(long id)
        {
            using (var conn = OpenConnection())
            {
                var obj = await conn.QuerySingleAsync<T>($"select * from {TableName} where id = @id", param: new { id });
                return obj;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            using (var conn = OpenConnection())
            {
                var list = await conn.QueryAsync<T>($"select * from {TableName}");
                return list;
            }
        }

        public async Task<long> Save(T obj)
        {
            using (var conn = OpenConnection())
            {
                var sql = GetInsertSql();
                var result = await conn.ExecuteScalarAsync<long>(sql, param: obj);
                return result;
            }
        }
    }
}
