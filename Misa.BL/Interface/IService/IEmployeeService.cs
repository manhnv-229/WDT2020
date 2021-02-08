using Misa.BL.Entity;
using Misa.BL.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IService
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region get employee
        /// <summary>
        /// lấy thông tin nhân vienen bằng mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns>thông tin nhân viên</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByEmployeeCode(string code);

        /// <summary>
        /// kiểm tra sự tồn tại của số điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByPhoneNumber(string phoneNumber);

        /// <summary>
        /// kiểm tra sự tồn tại của email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByEmail(string email);

        /// <summary>
        /// kiểm tra sự tồn tại của email
        /// </summary>
        /// <param name="taxCode"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByTaxCode(string taxCode);

        /// <summary>
        /// kiểm tra sự tồn tại của email
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByIDCard(string idCard);

        /// <summary>
        /// lấy thông tinh nhân viên bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách nhân viên</returns>
        /// <returns>thông tin của nhân viên</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        IEnumerable<Employee> GetEmployeesByName(string name, long page, long limmit);

        /// <summary>
        /// lấy danh sách nhân viên bằng vị trí của nhân viên có phân trang
        /// </summary>
        /// <param name="employeePositionId"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        IEnumerable<Employee> GetEmployeesByEmployeePosition(string employeePositionId, long page, long limmit);

        /// <summary>
        /// lấy danh sách nhân viên bằng bộ phận có phân trang
        /// </summary>
        /// <param name="employeeDepartmentId"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        IEnumerable<Employee> GetEmployeesByEmployeeDepartment(string employeeDepartmentId, long page, long limmit);

        /// <summary>
        /// lấy danh sách nhân viên bằng vị trí của nhân viên và bộ phận có phân trang
        /// </summary>
        /// <param name="employeePositionId"></param>
        ///  <param name="employeeDepartmentId"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        IEnumerable<Employee> GetEmployeesByPositionAndDepartment(string employeePositionId, string employeeDepartmentId, long page, long limmit);

        /// <summary>
        /// lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>mã lớn nhất</returns>
        /// createdBy: Mạnh Tiến(3/1/2020)
        string GetEmployeeCodeMax();
        #endregion

        #region count employee with field name
        /// <summary>
        /// tính tổng số lượng nhân viên với tham số vị trí và bộ phận cho trước
        /// </summary>
        /// <param name="posiId"></param>
        /// <param name="deparId"></param>
        /// <returns>số lượng nhân viên</returns>
        /// createdBy: Mạnh Tiến(31/12/2020)
        long CountEmployeeByPositionIdAndDepartmentId(string posiId, string deparId);

        /// <summary>
        /// tính tổng số lượng nhân viên với tham số vị trí
        /// </summary>
        /// <param name="posiId"></param>
        /// <returns>số lượng nhân viên</returns>
        /// createdBy: Mạnh Tiến(31/12/2020)
        long CountEmplyeeByEmployeePosiId(string posiId);

        /// <summary>
        /// tính tổng số lượng nhân viên bộ phận cho trước
        /// </summary>
        /// <param name="deparId"></param>
        /// <returns>số lượng nhân viên</returns>
        /// createdBy: Mạnh Tiến(31/12/2020)
        long CountEmplyeeByEmployeeDeparId(string deparId);

        /// <summary>
        /// số lượng nhân viên chứa tên được tìm kiếm
        /// </summary>
        /// <param name="name"></param>
        /// <returns>số lượng nhân viên</returns>
        /// createdBy: Mạnh Tiến(3/1/2020)
        long CountEmployeeByName(string name);

        /// <summary>
        /// lấy số lượng nhân viên
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Số lượng nhân viên</returns>
        /// createdBy: Mạnh Tiến(31/1/20121)
        long CountEmployeeByKey(string key);
        #endregion

        #region search employee with key
        /// <summary>
        /// lấy nhân viên theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Danh sách nhan viên</returns>
        /// createdBy: Mạnh Tiến(31/12/2020)
        IEnumerable<Employee> SearchEmployee(string key, long page, long limmit);
        #endregion

        #region delete employee
        /// <summary>
        /// xóa nhân viên bằng mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns>số nhân viên bị xóa</returns>
        /// createdBy: Mạnh Tiến(31/12/2020)
        ServiceResult DeleteEmployeeByCode(string code);

        /// <summary>
        /// xóa nhân viên theo danh sách nhân viên
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>số nhân viên bị xóa</returns>
        /// createdBy: Manh Tien (31/1/2021)
        ServiceResult DeleteEmployeesByListId(List<string> ids);

        /// <summary>
        /// xóa nhân viên theo danh sách mmã nhân viên
        /// </summary>
        /// <param name="codes"></param>
        /// <returns>số nhân viên bị xóa</returns>
        /// createdBy: Manh Tien (31/1/2021)
        ServiceResult DeleteEmployeeByListCode(List<string> codes);
        #endregion
    }
}
