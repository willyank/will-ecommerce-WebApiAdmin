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

        [Route("paginated")]
        [HttpGet]
        public async Task<ActionResult<T>> GetPaginated(
            [FromQuery] int page = 0, 
            [FromQuery] int rowsPage = 50, 
            [FromQuery] string columnOrder = null,
            [FromQuery] bool descending = false)
        {
            var list = await baseCrudService.GetPaginated(page, rowsPage, columnOrder, descending);
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
                return BadRequest(ModelState.Values);
            }
            var total = await baseCrudService.Save(obj);
            return Ok(total);
        }

        [Route("")]
        [HttpPut]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<long>> Put([FromBody] T obj)
        {
            return await Post(obj);
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
