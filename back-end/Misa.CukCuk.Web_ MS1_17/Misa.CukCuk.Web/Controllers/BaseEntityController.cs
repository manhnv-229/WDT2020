using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Data;
using Misa.CukCuk.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        protected DatabaseConnector _dbConnector;
        public BaseEntityController()
        {
            _dbConnector = new DatabaseConnector();
        }
        // GET: api/<CustomersController1>
        [HttpGet]
        public virtual IActionResult Get()
        {
           
            var customers = _dbConnector.GetData<TEntity>();
            return Ok(customers);
        }

        // GET api/<CustomersController1>/5
        [HttpGet("{customerId}")]
        public  IActionResult Get(Guid customerId)
        {
         
            var customers = _dbConnector.GetById<TEntity>(customerId);
            return Ok(customers);
        }

        // POST api/<CustomersController1>
        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntity customer)
        {
           // customer.CustomerId = Guid.NewGuid();
          
            var effectRows = _dbConnector.Insert<TEntity>(customer);
            return Ok(effectRows);
        }

        // PUT api/<CustomersController1>/5
        [HttpPut("{id}")]
        public  IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<CustomersController1>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             return Ok();
        }
    }
}
