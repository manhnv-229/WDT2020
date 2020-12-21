using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {
        DbConnector dbConnector;
        public CustomerGroupsController()
        {
            dbConnector = new DbConnector();
        }
        // GET: api/<CustomerGroups>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<CustomerGroup>());
        }

        // GET api/<CustomerGroups>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.getByID<CustomerGroup>(id));
        }

        // POST api/<CustomerGroups>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerGroups>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerGroups>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
