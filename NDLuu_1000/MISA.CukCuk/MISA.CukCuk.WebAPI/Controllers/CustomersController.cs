using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.WebAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
       /* [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<CustomersController>/5
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();
            String connectionString = "User Id=nvmanh;password = 12345678;Host=103.124.92.43;port = 3306;Database = MS_NVMANH_CukCuk;" +
                "Character Set=compatibility";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                customers = db.Query<Customer>("Select CustomerID,CustomerCode,FullName,PhoneNumber from Customer").ToList();
            }
            return customers;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
