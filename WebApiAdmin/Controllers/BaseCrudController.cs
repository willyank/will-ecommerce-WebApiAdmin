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

        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var obj = await baseCrudService.Get(id);
            return Ok(obj);
        }

        [Route("")]
        public async Task<IActionResult> Post([FromBody] T obj)
        {
            var total = await baseCrudService.Save(obj);
            return Ok(total);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var total = await baseCrudService.Delete(id);
            return Ok(total);
        }
    }
}
