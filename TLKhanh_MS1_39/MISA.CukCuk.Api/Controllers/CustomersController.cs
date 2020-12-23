using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using MISA.BL;
using MISA.Common;
using MISA.BL.Intefaces;
using Microsoft.AspNetCore.Cors;

namespace MISA.CukCuk.Api.Controllers
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
        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerBL.GetAllCustomer<Customer>());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var customer = _customerBL.GetCustomerById<Customer>(id);
            if(customer == null)
            {
                return BadRequest("Khách hàng không tồn tại!");
            }
            else
            {
                return Ok(customer);
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var affectedRows = _customerBL.InsertCustomer(customer);
            if(affectedRows == -1)
            {
                return BadRequest("Khách hàng này đã tồn tại!");
            }
            if(affectedRows == -2)
            {
                return BadRequest("Số điện thoại đã tồn tại!");
            }
            return Ok(affectedRows);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Customer customer)
        {
            var affectedRows = _customerBL.UpdateCustomer(id, customer);
            if(affectedRows == 0)
            {
                return BadRequest("Khách hàng không tồn tại!");
            }
            else
            {
                return Ok("Cập nhật thông tin khách hàng thành công.");
            }
        }

        //// DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var affectedRows = _customerBL.DeleteCustomer(id);
            if (affectedRows == 0)
            {
                return BadRequest("Khách hàng không tồn tại!");
            }
            else
            {
                return Ok("Xóa khách hàng thành công.");
            }
        }
    }
}
