using Misa.BL.Emum;
using Misa.BL.Result;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using Misa.BL.ServiceImp;

namespace Misa.BL
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository _cusRepo) : base(_cusRepo)
        {
            customerRepository = _cusRepo;
        }

        public Customer GetCustomerByCustomerCode(string code)
        {
            return customerRepository.GetCustomerByCustomerCode(code);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return customerRepository.GetCustomerByEmail(email);
        }

        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            return customerRepository.GetCustomerbyPhoneNumber(phoneNumber);
        }
    }
}
