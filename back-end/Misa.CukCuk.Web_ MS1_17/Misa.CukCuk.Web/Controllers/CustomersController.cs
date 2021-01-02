using Dapper;
using Microsoft.AspNetCore.Mvc;
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
            string connectionStirng = "Host = 103.124.92.43; Port = 3306; " +
                "Database = MS1_17_NguyenHuuHung_CukCuk; User Id = nvmanh;" +
                " Password = 12345678; Character Set=utf8";
            IDbConnection dbconnection = new MySqlConnection(connectionStirng);
            var customers = dbconnection.Query<Customer>("Select * from Customer");

            return customers;
        }

        // GET api/<CustomersController1>/5
        [HttpGet("{customerId}")]
        public Customer Get(Guid customerId)
        {
            string connectionStirng = "Host = 103.124.92.43; Port = 3306; " +
               "Database = MS1_17_NguyenHuuHung_CukCuk; User Id = nvmanh;" +
               " Password = 12345678; Character Set=utf8";
            IDbConnection dbconnection = new MySqlConnection(connectionStirng);
            string sql = $"select * from Customer where CustomerId = '{customerId.ToString()}'";
            var customer = dbconnection.Query<Customer>(sql).FirstOrDefault();
            return customer;
        }

        // POST api/<CustomersController1>
        [HttpPost]
        public int Post([FromBody] Customer customer)
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
