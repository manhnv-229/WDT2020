using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_MISA.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_MISA.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/<EmployeesController>
        DBConnector dbConnector;
        public EmployeesController()
        {
            dbConnector = new DBConnector();
        }
        public bool CheckDuplicateCode(string code)
        {
            var employee = DBConnector.Query<Employee>($"SELECT * FROM Employee WHERE EmployeeCode = '{code}'");
            if (employee != null)
            {
                return true;
            }
            return false;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<Employee>());
        }
        [HttpGet]
        public IActionResult Get( [FromQuery] string code, [FromQuery] string name,[FromQuery] string phone)
        {
            return Ok(dbConnector.GetDataByCodeNamePhone<Employee>(code, name, phone));
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if(CheckDuplicateCode(employee.EmployeeCode)==true)
            {
                return BadRequest("Ma Bi Trung");
            }
            return Ok(dbConnector.Insert<Employee>(employee));
        }
        [HttpDelete]
        public IActionResult Delete(string code)
        {
            return Ok(dbConnector.DeleteEmployeeByCode<Employee>(code));
        }
        [HttpPut]
        public IActionResult Update(string code)
        {
            return Ok(dbConnector.UpdateEmployeeByCode<Employee>(code));
        }

    }
}
