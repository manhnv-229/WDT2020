using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeBL _employeeBL;
        public EmployeesController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeBL.GetEmployees());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{EmployeeID}")]
        public IActionResult Get(String EmployeeID)
        {
            return Ok(_employeeBL.GetEmployeeByID(EmployeeID));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var effectRow = _employeeBL.InsertEmployee(employee);
            if (effectRow == -1)
            {
                return BadRequest("Mã bị trùng");
            }

            return Ok(effectRow);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(String id, [FromBody] Employee employee)
        {
            var e = _employeeBL.UpdateEmployee(employee);
           return Ok(e);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{EmployeeID}")]
        public IActionResult Delete(String EmployeeID)
        {
            return Ok(_employeeBL.DeleteEmployee(EmployeeID));
        }
    }
}
