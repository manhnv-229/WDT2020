using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Interfaces;
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
        ICustomerBL _customerBL;
        public CustomersController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _customerBL.GetCustomers();
            return Ok(entity);
        }

        /* 
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(db.getByID<Customer>(id));
        }*/

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            //CustomerBL customerBL = new CustomerBL();
            var effectRow = _customerBL.InsertCustomer(customer);
            if (effectRow==-1)
            {
                return BadRequest("Mã bị trùng");
            }

            return Ok(effectRow);
        }

    }
}
