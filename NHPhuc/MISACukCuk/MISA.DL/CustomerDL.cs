using Dapper;
using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class CustomerDL:Dbconnector, ICustomerDL
    {
        public bool CheckDuplicateCode(string code)
        {
            var customer = db.Query<Customer>($"SELECT * FROM Customer WHERE CustomerCode = '{code}'").FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer customer)
        {
            Dbconnector dbConnnector = new Dbconnector();
            return dbConnnector.Insert<Customer>(customer);
        }
    }
}
