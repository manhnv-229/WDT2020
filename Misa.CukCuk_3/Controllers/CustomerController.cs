
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Misa.CukCuk_3.Controllers
{
   
    public class CustomerController : BaseEntityController<Customer>
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerGroupId}/{page}/{limmit}")]
        public IEnumerable<Customer> GetCustomerByCustomerGroupd(string customerGroupId, long page, long limmit)
        {
            var customers = _customerService.GetCustomerByCustomerGroupId(customerGroupId, page, limmit);
            return customers;
        }

        [HttpGet("numberCustomerByCustomerGroupId/{id}")]
        public long NumberCustomerByCustomerGroupId(string id)
        {
            return _customerService.CountCustomerByGroupId(id);
        }
    }
}
