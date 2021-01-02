using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface IEmployeeDAO
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeByID(String id);

    }
}
