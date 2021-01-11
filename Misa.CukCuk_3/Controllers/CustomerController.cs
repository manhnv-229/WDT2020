
using Misa.BL.Interface.IService;
using Misa.BL.Entity;

namespace Misa.CukCuk_3.Controllers
{
   
    public class CustomerController : BaseEntityController<Customer>
    {
        ICustomerService _baseService;
        public CustomerController(ICustomerService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
