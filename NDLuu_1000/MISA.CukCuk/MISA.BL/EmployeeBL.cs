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
        public EmployeeBL(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }
        public Employee GetEmployeeByID(string id)
        {
            return _employeeDAO.GetEmployeeByID(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDAO.GetEmployees();
        }
    }
}
