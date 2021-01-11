using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.ServiceImp
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        ICustomerGroupRepository _repo;
        public CustomerGroupService(ICustomerGroupRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
