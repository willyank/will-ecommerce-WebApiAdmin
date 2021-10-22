using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.DatabaseFactories;
using WebApiAdmin.Repositories.Interfaces;

namespace WebApiAdmin.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IConnectionFactory connFacotry) : base(connFacotry)
        {

        }
    }
}
