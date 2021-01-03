using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IEmployeeBL
    {
        //Lấy tất cả nhân viên
        IEnumerable<Employee> GetEmployees();

        //Lấy nhân viên theo ID
        Employee GetEmployeeByID(String id);

        //Thêm mới nhân viên
        int InsertEmployee(Employee employee);

        //Cập nhật nhân viên
        int UpdateEmployee(Employee employee);

        //Xoá nhân viên
        int DeleteEmployee(string id);

    }
}
