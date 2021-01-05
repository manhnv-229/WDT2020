/*using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Web_MISA.Controllers.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_MISA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        Dbconnector dbConnector;
        public CustomerGroupController()
        {
            dbConnector = new Dbconnector();
        }
        // GET: api/<ValuesController>ng)
        // GET api/<ValuesController>/5
        //[HttpGet]
        //public Customer Get()
        //{
        //   var customer = new Customer();
        //   var a = Customer.SchoolName; 
        //   customer.Field = "Phuc";
        //  customer.MyProperty = "Phuc";
        // return customer;
        // }

        [HttpGet]
        public IActionResult Get()
        {
    
            return Ok(dbConnector.GetAllData<CustomerGroup>());
        }
    }
}
*/