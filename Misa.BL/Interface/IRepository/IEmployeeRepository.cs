using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IRepository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        #region get fucntion
        /// <summary>
        /// lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>mã lớn nhất</returns>
        /// createdBy: Mạnh Tiến(3/1/2020)
        string GetEmployeeCodeMax();
        #endregion


        /// <summary>
        /// xóa nhân viên bằng mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns>số nhân viên bị xóa</returns>
        /// createdBy: Mạnh Tiến(31/12/2020)
        int DeleteEmployeeByEmployeeCode(string code);
    }
}
