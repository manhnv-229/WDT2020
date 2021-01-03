using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Model;
using Misa.CukCuk.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{

    public class CustomersController : BaseEntityController<Customer>
    {

        public override IActionResult Get()
        {
            var sql = "select * from Customer Limit 2";

            return Ok(_dbConnector.GetData<Customer>(sql));
        }
        /*
        add new data
        */
        public override IActionResult Post([FromBody] Customer customer)
        {
            CustomerService customerService = new CustomerService();
            var res = customerService.InsertCustomer(customer);

            switch (res.MISACode)
            {
                case Enum.MISAServiceCode.BadRequest:
                    return Ok(res);
                case Enum.MISAServiceCode.Success:
                    return BadRequest(res);
                case Enum.MISAServiceCode.Exception:
                    return StatusCode(500);

                default:
                    return Ok();
            }
        }
    }
}
