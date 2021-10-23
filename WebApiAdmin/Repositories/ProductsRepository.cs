using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Repositories.DatabaseFactories;
using WebApiAdmin.Repositories.Interfaces;

namespace WebApiAdmin.Repositories
{
    public class ProductsRepository: BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IConnectionFactory connFacotry) : base(connFacotry)
        {

        }
    }
}
