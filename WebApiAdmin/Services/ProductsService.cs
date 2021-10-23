using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.Interfaces;

namespace WebApiAdmin.Services
{
    public class ProductsService : BaseCrudService<Product>
    {
        public ProductsService(IProductsRepository repo) : base(repo)
        {

        }
    }
}
