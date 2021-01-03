using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class DepartmentBL:IDepartmentBL
    {
        IDepartmentDAO _departmentDAO;
        public DepartmentBL(IDepartmentDAO departmentDAO)
        {
            _departmentDAO = departmentDAO;
        }

        
        public IEnumerable<Department> getALLData()
        {
           //xử lý nghiệp vụ

            return _departmentDAO.getALLData();
        }

        public Department getByID(string id)
        {
            throw new NotImplementedException();
        }
    }
}
