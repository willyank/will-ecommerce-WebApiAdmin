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
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : BaseCrudController<Category>
    {

        public CategoriesController(CategoriesService categoryService) : base(categoryService)
        {

        }
    }
}
