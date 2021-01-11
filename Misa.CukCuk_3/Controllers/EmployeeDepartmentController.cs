using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk_3.Controllers
{
    public class EmployeeDepartmentController : BaseEntityController<EmployeeDepartment>
    {
        IEmployeeDepartmentService _empDerService;
        public EmployeeDepartmentController(IEmployeeDepartmentService edService) : base(edService)
        {
            _empDerService = edService;
        }
    }
}
