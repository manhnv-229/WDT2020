using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common;
using MISA.DL;
using MISA.BL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase // muốn sửa tên class : ctrl + r + r
    {
        /*DbConnector dbConnector;

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
*/


        /* // GET api/<CustomersController>/5
         *//*        [HttpGet("{CustomerId}")]
                 public Customer Get(Guid CustomerId )
                 {
                     var customer = new Customer();
                     using (IDbConnection db = new MySqlConnection(connectionString))
                     {
                         var sqlQuery = $"select * from Customer where CustomerId='{CustomerId.ToString()}'";
                         customer = db.Query<Customer>(sqlQuery).FirstOrDefault();

                     }
                     return customer;

                 }*/
        /*[HttpGet("{Id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.GetById<Customer>(id));
        }

        [HttpGet("search")]
        public IActionResult Get([FromQuery] string code, [FromQuery] string phone)
        {
            return Ok(dbConnector.GetDataByCodeAndPhone<Customer>(code,phone));
        }*/

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            CustomerBL customerBL = new CustomerBL();
            var rowEffects = customerBL.InsertCustomer(customer);
            if(rowEffects == -1)
            {
                return BadRequest("Mã trùng rồi nhé bro!");
            }
            else
            {
                return Ok(rowEffects);
            }
            
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
