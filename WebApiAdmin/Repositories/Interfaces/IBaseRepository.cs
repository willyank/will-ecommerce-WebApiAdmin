using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAdmin.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task<long> Save(T obj);
        Task<int> Delete(long id);
    }
}
