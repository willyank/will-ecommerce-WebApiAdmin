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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : BaseCrudController<Category>
    {

        public CategoryController(CategoryService categoryService) : base(categoryService)
        {

        }


    }
}
