using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController1>
        [HttpGet]
        public Customer Get()
        {
            var customer = new Customer();
            customer.Field = "MM";

            return customer;
        }

        // GET api/<CustomersController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
