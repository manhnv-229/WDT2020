using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface IEmployeeDAO
    {
        //Lấy tất cả các nhân viên
        IEnumerable<Employee> GetEmployees();

        //Lấy nhân viên theo ID
        Employee GetEmployeeByID(String id);

        //Thêm nhân viên
        int InsertEmployee(Employee employee);

        //Check trùng mã nhân viên
        bool checkDuplicateEmployeeCode(String employeeCode);

        //Cập nhật nhân viên
        int UpdateEmployee(Employee employee);

        //Xoá nhân viên
        int DeleteEmployee(String id);
    }
}
