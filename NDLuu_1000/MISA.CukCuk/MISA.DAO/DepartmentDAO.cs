using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO
{
    public class DepartmentDAO : DbConnector, IDepartmentDAO
    {
        public IEnumerable<Department> getALLData()
        {
            var db = new DbConnector();
            return db.GetAllData<Department>();
        }

        public Department getByID(string id)
        {
            var db = new DbConnector();
            return db.getByID<Department>(id);
        }
    }
}
