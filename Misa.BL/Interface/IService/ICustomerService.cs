using Misa.BL.Entity;
using Misa.BL.Result;
using System.Collections.Generic;

namespace Misa.BL.Interface.IService
{
    public interface ICustomerService : IBaseService<Customer>
    {
        #region get customer
        /// <summary>
        /// lấy khách hàng theo mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns>danh sách khách hàng</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByCustomerCode(string code);

        /// <summary>
        /// lấy khách hàng theo điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>danh sách khách hàng</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByPhoneNumber(string phoneNumber);

        /// <summary>
        /// lấy khách hàng theo email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>danh sách khách hàng</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// lấy khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách khách hàng</returns>
        /// createdBy: Mạnh Tiến(6/2/2021)
        IEnumerable<Customer> GetCustomerByFullName(string fullName, long page, long limmit);

        /// <summary>
        /// lấy khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách khách hàng</returns>
        /// createdBy: Mạnh Tiến(6/2/2021)
        IEnumerable<Customer> GetCustomerByCustomerGroupId(string id, long page, long limmit);
        #endregion

        #region count customer
        /// <summary>
        /// tổng khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns>số lượng khách hàng; long</returns>
        /// CreadtedBy: Mạnh Tiến(6/2/2021)
        long CountCustomerByGroupId(string id);
        #endregion
    }
}
