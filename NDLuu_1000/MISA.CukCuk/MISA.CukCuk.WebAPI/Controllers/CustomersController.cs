using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.Common;
using MISA.DAO;
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
       /* DbConnector db;
        public CustomersController()
        {
             db = new DbConnector();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.GetAllData<Customer>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(db.getByID<Customer>(id));
        }*/

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            CustomerBL customerBL = new CustomerBL();

            return Ok();
        }

    }
}
