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
    public class BaseEntityController<NVMANH> : ControllerBase
    {
        protected DatabaseConnector _dbConnector;
        public BaseEntityController()
        {
            _dbConnector = new DatabaseConnector();
        }
        // GET: api/<CustomersController1>
        [HttpGet]
        public virtual IEnumerable<NVMANH> Get()
        {
           
            var customers = _dbConnector.GetData<NVMANH>();
            return customers;
        }

        // GET api/<CustomersController1>/5
        [HttpGet("{customerId}")]
        public  NVMANH Get(Guid customerId)
        {
         
            var customers = _dbConnector.GetById<NVMANH>(customerId);
            return customers;
        }

        // POST api/<CustomersController1>
        [HttpPost]
        public int Post([FromBody] NVMANH customer)
        {
           // customer.CustomerId = Guid.NewGuid();
          
            var effectRows = _dbConnector.Insert<NVMANH>(customer);
            return effectRows;
        }

        // PUT api/<CustomersController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
