using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAdmin.Services;

namespace WebApiAdmin.Controllers
{
    public class BaseCrudController<T> : ControllerBase
    {
        BaseCrudService<T> baseCrudService;

        public BaseCrudController(BaseCrudService<T> baseCrudService): base()
        {
            this.baseCrudService = baseCrudService;
        }

        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var list = await baseCrudService.GetAll();
            return Ok(list);
        }
    }
}
