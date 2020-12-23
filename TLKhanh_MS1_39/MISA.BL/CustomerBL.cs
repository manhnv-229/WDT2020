using MISA.BL.Intefaces;
using MISA.Common;
using MISA.DL;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class CustomerBL : ICustomerBL
    {
        ICustomerDL _customerDL;
        public CustomerBL(ICustomerDL customerDL)
        {
            _customerDL = customerDL;
        }
        public IEnumerable<Customer> GetAllCustomer<Customer>()
        {
            return _customerDL.GetAllCustomer<Customer>();
        }
        public IEnumerable<Customer> GetCustomerById<Customer>(string id)
        {
            if (_customerDL.CheckCustomerExists(id) == true)
            {
                return _customerDL.GetCustomerById<Customer>(id);

            }
            else
            {
                return null;
            }
        }

        public int InsertCustomer(Customer customer)
        {
            if (_customerDL.CheckDuplicateCustomerCode(customer.CustomerCode) == true)
            {
                return -1;
            }
            if (_customerDL.CheckDuplicatePhoneNumber(customer.PhoneNumber) == true) {
                return -2;
            }
            return _customerDL.InsertCustomer(customer);
        }
        public int UpdateCustomer(string id, Customer customer)
        {
            if (_customerDL.CheckCustomerExists(id) == true)
            {
                return _customerDL.UpdateCustomer(id, customer);

            }
            else
            {
                return 0;
            }
        }

        public int DeleteCustomer(string id)
        {
            if (_customerDL.CheckCustomerExists(id) == true)
            {
                return _customerDL.DeleteCustomer(id);

            }
            else
            {
                return 0;
            }
        }
        
    }
}
