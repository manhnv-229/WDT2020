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
    public class PositionsController : ControllerBase
    {
        IPositionBL _positionBL;
        public PositionsController(IPositionBL positionBL)
        {
            _positionBL = positionBL;
        }
        // GET: api/<PositionsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_positionBL.getAllData());
        }

        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PositionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
