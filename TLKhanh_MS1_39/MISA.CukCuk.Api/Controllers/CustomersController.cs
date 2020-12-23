using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        DbConnector dbConnector;
        public CustomersController()
        {
            dbConnector = new DbConnector();
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<Customer>());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.GetById<Customer>(id));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            return CreatedAtAction("POST",dbConnector.Insert<Customer>(customer));
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Customer customer)
        {
            return Ok(dbConnector.UpdateById<Customer>(id, customer));
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(dbConnector.DeleteById<Customer>(id));
        }
    }
}
