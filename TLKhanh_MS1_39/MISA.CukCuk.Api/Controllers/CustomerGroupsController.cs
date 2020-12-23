using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {
        DbConnector dbConnector;
        public CustomerGroupsController()
        {
            dbConnector = new DbConnector();
        }
        // GET: api/<CustomerGroupsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<CustomerGroup>());
        }

        // GET api/<CustomerGroupsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.GetById<CustomerGroup>(id));
        }

        // POST api/<CustomerGroupsController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {
            return CreatedAtAction("POST", dbConnector.Insert<CustomerGroup>(customerGroup));
        }

        // PUT api/<CustomerGroupsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CustomerGroup customerGroup)
        {
            return Ok(dbConnector.UpdateById<CustomerGroup>(id, customerGroup));
        }

        // DELETE api/<CustomerGroupsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(dbConnector.DeleteById<CustomerGroup>(id));
        }
    }
}
