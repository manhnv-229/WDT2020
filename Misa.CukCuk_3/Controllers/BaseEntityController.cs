using Microsoft.AspNetCore.Mvc;
using Misa.BL.Interface.IService;
using Misa.BL.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Misa.CukCuk_3.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        IBaseService<T> _baseService;
        public BaseEntityController(IBaseService<T> baseService)
        {
            this._baseService = baseService;
        }
        // GET: api/<BaseController>
        [HttpGet]
        public IEnumerable<T> Get()
        {
            long totalRow = _baseService.CountEntity();
            return _baseService.GetEntity(0, totalRow);
        }

        [HttpGet("{page}/{limmit}")]
        public IEnumerable<T> GetEntities(long page, long limmit)
        {
            var entities = _baseService.GetEntity(page, limmit);
            return entities;
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public T Get(string id)
        {
            return _baseService.GetEntityById(id);
        }

        [HttpGet("numberEntity")]
        public long GetNumberEntity()
        {

            return _baseService.CountEntity();
        }

        // POST api/<BaseController>
        [HttpPost]
        public ServiceResult Post([FromBody] T entity)
        {
            return _baseService.InsertT(entity);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public ServiceResult Put([FromBody] T entity, string id)
        {
            return _baseService.UpdateT(entity, id);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public ServiceResult Delete(string id)
        {
            return _baseService.DeleteT(id);
        }

    }
}
