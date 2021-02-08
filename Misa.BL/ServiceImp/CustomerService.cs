using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using Misa.BL.ServiceImp;
using System.Collections.Generic;
using System.Linq;

namespace Misa.BL
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository _cusRepo) : base(_cusRepo)
        {
            customerRepository = _cusRepo;
        }

        #region get customer
        public Customer GetCustomerByCustomerCode(string code)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("CustomerCode");
            values.Add(code);
            return customerRepository.GetData(0, 1,fieldNames, values).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomerByCustomerGroupId(string id, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("CustomerGroupId");
            values.Add(id);
            return customerRepository.GetData(page, limmit, fieldNames, values);
        }

        public Customer GetCustomerByEmail(string email)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("Email");
            values.Add(email);
            return customerRepository.GetData(0, 1, fieldNames, values).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomerByFullName(string fullName, long page, long limmit)
        {
            fullName = fullName.Trim();
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("FullName");
            values.Add(fullName);
            return customerRepository.GetData(page, limmit, fieldNames, values);
        }

        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("PhoneNumber");
            values.Add(phoneNumber);
            return customerRepository.GetData(0, 1, fieldNames, values).FirstOrDefault();
        }
        #endregion

        #region count customer
        public long CountCustomerByGroupId(string id)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("CustomerGroupId");
            values.Add(id);
            return customerRepository.CountEntity(fieldNames, values);
        }
        #endregion
    }
}
