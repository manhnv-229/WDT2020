using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface ICustomerBL
    {
        int InsertCustomer(Customer customer);

        IEnumerable<Customer> GetCustomers();
    }
}
