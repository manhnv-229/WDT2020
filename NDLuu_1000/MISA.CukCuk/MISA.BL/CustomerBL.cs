using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL//xử lý nghiệp vụ
{
    public class CustomerBL:ICustomerBL
    {
        ICustomerDAO _customerDAO;
        public CustomerBL(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //xử lý
            return _customerDAO.GetCustomers();
        }

        public int InsertCustomer(Customer customer)
        {
            //1. check trùng mã...
            if (_customerDAO.checkDublicateCustomerCode(customer.CustomerCode) == true)
            {
                return -1;
            }
            else
            {
                var effectRow = _customerDAO.Insert(customer);
                return effectRow;
            }
            

            //2. Check các trường dl

        }
    }
}
