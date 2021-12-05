using EcommerceModels;
using NgStore.Framework.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories;

namespace WebApiAdmin.Services
{
    public class BaseCrudService<T> where T : BaseModel
    {
        private IBaseRepository<T> baseRepository;
        protected ILoggerService logger;
        public BaseCrudService(ILoggerService logger, IBaseRepository<T> repo)
        {
            this.baseRepository = repo;
            this.logger = logger;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await baseRepository.GetAll();
            return list;
        }

        public async Task<IEnumerable<T>> GetPaginated(int page, int rowsPage, string columnOrder)
        {
            var list = await baseRepository.GetPaginated(page, rowsPage, columnOrder);
            return list;
        }

        public async Task<int> Delete(long id)
        {
            return await baseRepository.Delete(id);
        }

        public async Task<T> Get(long id)
        {
            return await baseRepository.Get(id);
        }

        public virtual async Task<long> Save(T obj)
        {
            return await baseRepository.Save(obj);
        }
    }
}
