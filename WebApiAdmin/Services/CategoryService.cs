using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.Interfaces;

namespace WebApiAdmin.Services
{
    public class CategoryService : BaseCrudService<Category>
    {
        public CategoryService(ICategoryRepository repo): base(repo)
        {

        }
    }
}
