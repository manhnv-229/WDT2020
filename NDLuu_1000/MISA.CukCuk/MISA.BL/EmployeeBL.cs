using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeDAO _employeeDAO;
        //Hàm khởi tạo
        public EmployeeBL(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }

        /// <summary>
        /// Xoá nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: NDLuu (3/1/2021)
        public int DeleteEmployee(string id)
        {
            return _employeeDAO.DeleteEmployee(id);
        }

        /// <summary>
        /// Lấy nhân viên theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Nhân Viên</returns>
        /// Author: NDLuu (3/1/2021)
        public Employee GetEmployeeByID(string id)
        {
            return _employeeDAO.GetEmployeeByID(id);
        }

        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        ///  Author: NDLuu (3/1/2021)
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDAO.GetEmployees();
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>số bản ghi được thêm vào
        ///  Author: NDLuu (3/1/2021)</returns>
        public int InsertEmployee(Employee employee)
        {
            //Check Trùng mã
            if (_employeeDAO.checkDuplicateEmployeeCode(employee.EmployeeCode) == true)
            {
                return -1;
            }
            else
            {
                var effectRow = _employeeDAO.InsertEmployee(employee);
                return effectRow;
            }
        }

        /// <summary>
        /// Cập nhật Nhân Viên - Xử lý nghiệp vụ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateEmployee(Employee employee)
        {
            //Check trùng mã...

            var e =  _employeeDAO.UpdateEmployee(employee);
            return e;
        }
    }
}
