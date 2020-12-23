using Dapper;
using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class CustomerDL : DbConnector, ICustomerDL
    {
        DbConnector dbConnector = new DbConnector();

        public IEnumerable<Customer> GetAllCustomer<Customer>()
        {
            return dbConnector.GetAllData<Customer>();
        }

        public IEnumerable<Customer> GetCustomerById<Customer>(string id)
        {
            return dbConnector.GetById<Customer>(id);
        }

        public int InsertCustomer(Customer customer)
        {
            var affectedRows = dbConnector.Insert<Customer>(customer);
            return affectedRows;
        }

        public int UpdateCustomer(string id, Customer customer)
        {
            var affectedRows = dbConnector.UpdateById<Customer>(id, customer);
            return affectedRows;
        }

        public int DeleteCustomer(string id)
        {
            var affectedRows = dbConnector.DeleteById<Customer>(id);
            return affectedRows;
        }

        bool ICustomerDL.CheckDuplicateCustomerCode(string code)
        {
            var customer = dbConnection.Query<Customer>(
                $"SELECT * FROM Customer WHERE CustomerCode = '{code}'").FirstOrDefault();
            if (customer == null)
            {
                return false;
            }
            return true;
        }
        public bool CheckDuplicatePhoneNumber(string phone)
        {
            var customer = dbConnection.Query<Customer>(
                $"SELECT * FROM Customer WHERE PhoneNumber = '{phone}'").FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            return false;
        }
        public bool CheckCustomerExists(string id)
        {
            var customer = dbConnection.Query<Customer>(
                $"SELECT * FROM Customer WHERE CustomerId = '{id}'").FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            return false;
        }

    }
}
