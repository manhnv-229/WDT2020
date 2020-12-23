using Microsoft.AspNetCore.Mvc;
using MISA.BL.Intefaces;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {
        ICustomerGroupBL _customerGroupBL;
        public CustomerGroupsController(ICustomerGroupBL customerGroupBL)
        {
            _customerGroupBL = customerGroupBL;
        }
        // GET: api/<CustomerGroupsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerGroupBL.GetAllCustomerGroup<CustomerGroup>());
        }

        // GET api/<CustomerGroupsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var customerGroup = _customerGroupBL.GetCustomerGroupById<CustomerGroup>(id);
            if(customerGroup == null)
            {
                return BadRequest("Nhóm khách hàng không tồn tại!");
            }
            else
            {
                return Ok(customerGroup);
            }
        }

        // POST api/<CustomerGroupsController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {
            var affectedRows = _customerGroupBL.InsertCustomerGroup(customerGroup);
            if (affectedRows == 0)
            {
                return BadRequest("Thêm thất bại!");
            }
            else
            {
                return Ok("Thêm thành công.");
            }
        }

        // PUT api/<CustomerGroupsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CustomerGroup customerGroup)
        {
            var affectedRows = _customerGroupBL.UpdateCustomerGroup(id, customerGroup);
            if (affectedRows == 0)
            {
                return BadRequest("Sửa thất bại, Nhóm khách hàng không tồn tại!");
            }
            else
            {
                return Ok("Sửa thành công.");
            }
        }

        // DELETE api/<CustomerGroupsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var affectedRows = _customerGroupBL.DeleteCustomerGroup(id);
            if (affectedRows == 0)
            {
                return BadRequest("Xóa thất bại, Nhóm khách hàng không tồn tại!");
            }
            else
            {
                return Ok("Xóa thành công.");
            }
        }
    }
}
