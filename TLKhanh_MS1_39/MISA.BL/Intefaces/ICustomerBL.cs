using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Intefaces
{
    public interface ICustomerBL
    {
        IEnumerable<Customer> GetAllCustomer<Customer>();
        IEnumerable<Customer> GetCustomerById<Customer>(string id);
        int InsertCustomer(Customer customer);
        int UpdateCustomer(String id, Customer customer);
        int DeleteCustomer(String id);
    }
}
