using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IDepartmentBL
    {
        IEnumerable<Department> getALLData();

        Department getByID(String id);
    }
}
