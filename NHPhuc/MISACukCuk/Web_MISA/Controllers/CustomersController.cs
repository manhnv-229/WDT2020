using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.interfaces;
using MISA.Common;
using MISA.DL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_MISA.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerBL _customerBL;
        public CustomersController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }
        /*
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CustomerBL.GetAllData<Customer>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.GetByID<Customer>(id));
        }
        [HttpGet("search")]
        public IActionResult Get([FromQuery]string phone, [FromQuery] string code)
        {
            return Ok(dbConnector.GetDataByPhoneAndCode<Customer>(phone, code));
        }*/

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var effectRows = _customerBL.InsertCustomer(customer);
            if(effectRows == -1)
            {
                return BadRequest("Ma Bi Trung");
            }
            return Ok(effectRows);
        }
    }
}

