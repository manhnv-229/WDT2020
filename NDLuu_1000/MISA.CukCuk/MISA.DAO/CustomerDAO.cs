using Dapper;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO
{
    public class CustomerDAO : DbConnector
    {
        public int InsertCustomer(Customer customer)
        {
            db.Query<Customer>("");
            
            return 0;
        }
    }
}
