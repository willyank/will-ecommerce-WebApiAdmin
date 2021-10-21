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
    }
}
