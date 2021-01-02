using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IEmployeeBL
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeByID(String id);
    }
}
