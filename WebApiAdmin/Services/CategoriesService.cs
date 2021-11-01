using EcommerceModels;
using NgStore.Framework.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.Interfaces;

namespace WebApiAdmin.Services
{
    public class CategoriesService : BaseCrudService<Category>
    {
        private ICategoriesRepository categoryRepository;
        public CategoriesService(ILoggerService logger, ICategoriesRepository repo): base(logger, repo)
        {
            this.categoryRepository = repo;
        }

        public override async Task<long> Save(Category obj)
        {
            if(obj.Color == "blue")
            {
                throw new Exception("blue nao pode");
            }
            return await categoryRepository.Save(obj);
        }
    }
}
