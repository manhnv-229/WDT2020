using Dapper;
using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Data;
using Misa.CukCuk.Web.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        public IEnumerable<Customer> Get()
        {
            var databaseConnector = new DatabaseConnector();
            var customers = databaseConnector.GetAll<Customer>();
            return customers;
        }

        // GET api/<CustomersController1>/5
        [HttpGet("{customerId}")]
        public Customer Get(Guid customerId)
        {
            var databaseConnector = new DatabaseConnector();
            var customers = databaseConnector.GetById<Customer>(customerId);
            return customers;
        }

        // POST api/<CustomersController1>
        [HttpPost]
        public int Post([FromBody] Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();
            var databaseConnector = new DatabaseConnector();
            var effectRows = databaseConnector.Insert<Customer>(customer);
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
