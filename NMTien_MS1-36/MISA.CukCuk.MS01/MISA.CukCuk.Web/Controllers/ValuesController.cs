using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/
        // GET api/<ValuesController>/5

        /* [HttpGet("abc/{name}&{id}")] // truyen value thong qua route
         public string Get(string name, int id)
         {
             return name ;
         }
         */
        [HttpGet("abc")] 
        public int? Get([FromQuery]string name, int? id)
        {
            return id;
        }

        // POST api/<ValuesController>
        /* [HttpPost]
         public string Post([FromBody] string value)
         {
             return value;
         }*/
        [HttpPost("{id}")]
        public string Post([FromBody] string name, int id)
        {
            return name;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
