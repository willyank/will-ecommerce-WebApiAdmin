using EcommerceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Services;

namespace WebApiAdmin.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : BaseCrudController<Product>
    {

        public ProductsController(ProductsService productsService) : base(productsService)
        {

        }


    }
}
