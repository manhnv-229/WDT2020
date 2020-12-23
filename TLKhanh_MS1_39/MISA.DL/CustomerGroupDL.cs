using Dapper;
using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class CustomerGroupDL : DbConnector, ICustomerGroupDL
    {
        DbConnector dbConnector = new DbConnector();
        public bool CheckCustomerGroupExists(string id)
        {
            var customer = dbConnection.Query<CustomerGroup>(
                $"SELECT * FROM CustomerGroup WHERE CustomerGroupId = '{id}'").FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            return false;
        }

        public int DeleteCustomerGroup(string id)
        {
            var affecredRows = dbConnector.DeleteById<CustomerGroup>(id);
            return affecredRows;
        }

        public IEnumerable<CustomerGroup> GetAllCustomerGroup<CustomerGroup>()
        {
            return dbConnector.GetAllData<CustomerGroup>();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroupById<CustomerGroup>(string id)
        {
            return dbConnector.GetById<CustomerGroup>(id);
        }

        public int InsertCustomerGroup(CustomerGroup customerGroup)
        {
            var affectedRows = dbConnector.Insert<CustomerGroup>(customerGroup);
            return affectedRows;
        }

        public int UpdateCustomerGroup(string id, CustomerGroup customerGroup)
        {
            var affectedRows = dbConnector.UpdateById<CustomerGroup>(id, customerGroup);
            return affectedRows;
        }
    }
}
