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
    public class WorkStatusController : ControllerBase
    {
        IWorkStatusBL _WorkStatusBL;
        public WorkStatusController(IWorkStatusBL WorkStatusBL)
        {
            _WorkStatusBL = WorkStatusBL;
        }
        // GET: api/<WorkStatusController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_WorkStatusBL.getAllData());
        }

        // GET api/<WorkStatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WorkStatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
