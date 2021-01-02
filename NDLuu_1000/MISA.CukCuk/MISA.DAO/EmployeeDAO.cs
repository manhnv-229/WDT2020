using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO
{
    public class EmployeeDAO : DbConnector, IEmployeeDAO
    {
        public Employee GetEmployeeByID(string id)
        {
            var db = new DbConnector();
            return db.getByID<Employee>(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var db = new DbConnector();
            return db.GetAllData<Employee>();
        }
    }
}
