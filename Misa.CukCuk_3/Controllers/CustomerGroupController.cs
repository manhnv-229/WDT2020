using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk_3.Controllers
{
    public class CustomerGroupController : BaseEntityController<CustomerGroup>
    {
        public ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupService cgService) : base(cgService)
        {
            _customerGroupService = cgService;
        }
    }
}
