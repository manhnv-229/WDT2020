using Dapper;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DAO//lấy data
{
    public class CustomerDAO : DbConnector,ICustomerDAO
    {
        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <param name="code"> Mã khách hàng</param>
        /// <returns>True nếu trùng, False nếu k trùng</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public bool checkDublicateCustomerCode(string code)
        {
            var x = db.Query<Customer>($"Select * from Customer where CustomerCode = '{code}'").FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lấy tất cả các khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public IEnumerable<Customer> GetCustomers()
        {
            DbConnector dbConnector = new DbConnector();
            var affect = dbConnector.GetAllData<Customer>();
            return affect;
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Khách hàng</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public int Insert(Customer customer)
        {
            DbConnector dbConnector = new DbConnector();
            var affect = dbConnector.Insert<Customer>(customer);
            return affect;
        }

        public int InsertCustomer(Customer customer)
        {
            db.Query<Customer>("");
            
            return 0;
        }
    }
}
