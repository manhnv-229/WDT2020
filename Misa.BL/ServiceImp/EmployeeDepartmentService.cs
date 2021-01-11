using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.ServiceImp
{
    public class EmployeeDepartmentService : BaseService<EmployeeDepartment>, IEmployeeDepartmentService
    {
        IEmployeeDepartmentRepository _repo;
        public EmployeeDepartmentService(IEmployeeDepartmentRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
