﻿using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;

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
