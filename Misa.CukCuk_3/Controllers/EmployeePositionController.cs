using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk_3.Controllers
{
    public class EmployeePositionController : BaseEntityController<EmployeePosition>
    {
        IEmployeePositionService _empPositionService;
        public EmployeePositionController(IEmployeePositionService empService) : base(empService)
        {
            _empPositionService = empService;
        }
    }
}
