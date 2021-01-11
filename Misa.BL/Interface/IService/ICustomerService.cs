using Misa.BL.Entity;
using Misa.BL.Result;

namespace Misa.BL.Interface.IService
{
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// kiểm tra sự tồn tại của mã khách hàng
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByCustomerCode(string code);

        /// <summary>
        /// kiểm tra sự tồn tại của số điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByPhoneNumber(string phoneNumber);

        /// <summary>
        /// kiểm tra sự tồn tại của email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        Customer GetCustomerByEmail(string email);
    }
}
