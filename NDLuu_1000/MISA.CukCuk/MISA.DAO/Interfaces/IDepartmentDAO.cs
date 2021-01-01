using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface IDepartmentDAO
    {
        IEnumerable<Department> getALLData();

        Department getByID(String id);

    }
}
