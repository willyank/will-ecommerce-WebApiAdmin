using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories;

namespace WebApiAdmin.Services
{
    public class BaseCrudService<T>
    {
        private IBaseRepository<T> baseRepository;
        public BaseCrudService(IBaseRepository<T> repo)
        {
            this.baseRepository = repo;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await baseRepository.GetAll();
        }

        public async Task<int> Delete(long id)
        {
            return await baseRepository.Delete(id);
        }

        public async Task<T> Get(long id)
        {
            return await baseRepository.Get(id);
        }

        public async Task<long> Save(T obj)
        {
            return await baseRepository.Save(obj);
        }
    }
}
