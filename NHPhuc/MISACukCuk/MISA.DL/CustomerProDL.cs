using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL
{
    public class CustomerProDL : ICustomerDL
    {
        public bool CheckDuplicateCode(string code)
        {
            return false;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return null;
        }

        public int Insert(Customer customer)
        {
            Dbconnector dbConnnector = new Dbconnector();
            return dbConnnector.Insert<Customer>(customer);
        }
    }
}
