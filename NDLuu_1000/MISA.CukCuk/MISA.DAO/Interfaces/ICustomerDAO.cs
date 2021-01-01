using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface ICustomerDAO
    {
        IEnumerable<Customer> GetCustomers();

        int Insert(Customer customer);

        bool checkDublicateCustomerCode(String code);



    }
}
