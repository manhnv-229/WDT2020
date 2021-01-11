using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.ServiceImp
{
    public class EmployeePositionService : BaseService<EmployeePosition>, IEmployeePositionService
    {
        IEmployeePositionRepository _repo;
        public EmployeePositionService(IEmployeePositionRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
