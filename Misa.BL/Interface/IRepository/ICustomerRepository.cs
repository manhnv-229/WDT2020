using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Lấy khách hàng bằng mã khách hàng 
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Một bản ghi</returns>
        /// CreatedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByCustomerCode(string code);

        /// <summary>
        /// Lấy khách hàng bằng email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Một bản ghi</returns>
        /// CreatedBy: Mạnh Tiến(25/12/2020) 
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// Lấy khách hàng bằng phoneNumber
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>Một bản ghi</returns>
        /// CreatedBy: Mạnh Tiến(25/12/2020) 
        Customer GetCustomerbyPhoneNumber(string phoneNumber);
    }
}
