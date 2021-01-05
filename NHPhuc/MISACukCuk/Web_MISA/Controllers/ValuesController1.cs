/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_MISA.Controllers.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_MISA.Controllers
{
    [Route("api/nhphuc")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        // GET: api/<ValuesController1>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
       //     return new string[] { "value1", "value2" };
        //}

        // GET api/<ValuesController1>/5
        [HttpGet]
        public Customer Get()
        {
            var customer = new Customer();
            return customer;
        }
        //[HttpGet("{name}")]
        //public string Get(string name)
        //{
        //    return name;
        //}
        // POST api/<ValuesController1>
        [HttpPost("{id}")]
        public string Post([FromBody] string value, int id)
        {
            return value;
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
*/