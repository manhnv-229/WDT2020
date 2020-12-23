using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface ICustomerDL
    {
        IEnumerable<Customer> GetAllCustomer<Customer>();
        IEnumerable<Customer> GetCustomerById<Customer>(string id);
        int InsertCustomer(Customer customer);
        int UpdateCustomer(String id, Customer customer);
        int DeleteCustomer(String id);
        bool CheckDuplicateCustomerCode(string code);
        bool CheckDuplicatePhoneNumber(string code);
        bool CheckCustomerExists(string id);
    }
}
