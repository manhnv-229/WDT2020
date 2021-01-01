using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        IDepartmentBL _departmentBL;
        public DepartmentsController(IDepartmentBL departmentBL)
        {
            _departmentBL = departmentBL;
        }

        // GET: api/<Departments>
        [HttpGet]
        public IActionResult Get()
        {
            var entity = _departmentBL.getALLData();
            return Ok(entity);
        }

        // GET api/<Departments>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Departments>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Departments>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Departments>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
