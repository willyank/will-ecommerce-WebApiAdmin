using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<Pagination<T>> GetPaginated(int page, int rowsPage, string columnOrder);
        Task<T> Get(long id);
        Task<long> Save(T obj);

        Task<int> Update(T obj);
        Task<int> Delete(long id);
    }
}
