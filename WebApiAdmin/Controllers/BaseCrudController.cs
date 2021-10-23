using EcommerceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiAdmin.Services;

namespace WebApiAdmin.Controllers
{
    public class BaseCrudController<T> : ControllerBase where T : BaseModel
    {
        BaseCrudService<T> baseCrudService;

        public BaseCrudController(BaseCrudService<T> baseCrudService) : base()
        {
            this.baseCrudService = baseCrudService;
        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<T>> GetAll()
        {
            var list = await baseCrudService.GetAll();
            return Ok(list);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<T>> Get(long id)
        {
            var obj = await baseCrudService.Get(id);
            return Ok(obj);
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<long>> Post([FromBody] T obj)
        {
            if (!ModelState.IsValid)
            {

            }
            var total = await baseCrudService.Save(obj);
            return Ok(total);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<long>> Delete(long id)
        {
            var total = await baseCrudService.Delete(id);
            return Ok(total);
        }
    }
}
