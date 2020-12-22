using Dapper;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL
{
    public class CustomerDL : DbConnector 
    {
        public int InsertCustomer(Customer customer)
        {
            DbConnector dbConnector = new DbConnector();
            //1. check trung ma:

            //2.check trung sdt:
            var affectRows = dbConnector.Insert<Customer>(customer);
            return affectRows;
        }
        public bool CheckDuplicateCustomerCode(string code)
        {
            var customer = dbConnection.Query<Customer>($"SELECT * FROM Customer");
            if (customer != null)
                return true;
            return false;
        }
    }
}
