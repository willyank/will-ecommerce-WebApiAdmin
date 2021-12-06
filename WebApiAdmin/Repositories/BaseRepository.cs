using Dapper;
using EcommerceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.DatabaseFactories;

namespace WebApiAdmin.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly IConnectionFactory connectionFactory;
        public BaseRepository(IConnectionFactory connFacotry)
        {
            connectionFactory = connFacotry;
        }

        public IDbConnection OpenConnection()
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

        private IEnumerable<PropertyInfo> Properties
        {
            get
            {
                return typeof(T).GetProperties().Where(w => w.Name != "Id");
            }
        }


        private string GetInsertSql()
        {
            var sql = $"insert into {TableName} ({{0}}) values ({{1}}) RETURNING id";

            var fields = Properties.Select(s => s.Name);
            var fieldsName = string.Join(",", fields);
            var fieldsParam = string.Join(",", fields.Select(field => $"@{field}"));

            return string.Format(sql, fieldsName, fieldsParam);
        }


        public async Task<int> Delete(long id)
        {
            using (var conn = OpenConnection())
            {
                var totalDeleted = await conn.ExecuteAsync($"delete from {TableName} where id = @Id", param: new { Id = id });
                return totalDeleted;
            }
        }

        public async Task<T> Get(long id)
        {
            using (var conn = OpenConnection())
            {
                var obj = await conn.QuerySingleAsync<T>($"select * from {TableName} where id = @Id", param: new { Id = id });
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

        public async Task<Pagination<T>> GetPaginated(int page, int rowsPage, string columnOrder)
        {
            if(!typeof(T).GetProperties().Any(any => any.Name.ToLower() == columnOrder?.ToLower()))
            {
                return null;
            }

            using (var conn = OpenConnection())
            {
                var query = @$"select 
                                    count(*) OVER() AS Total, 
                                    * 
                                from 
                                    {TableName} 
                                order by 
                                    {columnOrder}
                                limit 
                                    @rowsPage 
                                offset 
                                    @offset";
        
                var lookup = new Dictionary<long, Pagination<T>>();
                var query1 = await conn.QueryAsync<Pagination<T>, T, Pagination<T>>(query,
                    (page, obj) =>
                    {
                        Pagination<T> temp;
                        if (!lookup.TryGetValue(page.Total, out temp))
                        {
                            temp = page;
                            temp.Items = new List<T>();
                            lookup.Add(page.Total, temp);
                        }

                        if (obj != null)
                        {
                            temp.Items.Add(obj);
                        }

                        return temp;

                    },
                    param: new { columnOrder = columnOrder ?? "id", rowsPage, offset = page * rowsPage },
                    splitOn: "Total, id",
                    commandType: CommandType.Text);

                return lookup.Values.FirstOrDefault();
            }
        }


        public async Task<long> Save(T obj)
        {
            if(obj.Id > 0)
            {
                return await Update(obj);
            }

            using (var conn = OpenConnection())
            {
                var sql = GetInsertSql();
                var result = await conn.ExecuteScalarAsync<long>(sql, param: obj);
                return result;
            }
        }

        public async Task<int> Update(T obj)
        {
            using (var conn = OpenConnection())
            {
                var fields = Properties.Select(s => $"{s.Name}=@{s.Name}");
                var sql = $"update {TableName} set {{0}} where id = @Id";

                var sqlParams = string.Format(sql, string.Join(", ", fields));
                var result = await conn.ExecuteAsync(sqlParams, param: obj);
                return result;
            }
        }
    }
}
