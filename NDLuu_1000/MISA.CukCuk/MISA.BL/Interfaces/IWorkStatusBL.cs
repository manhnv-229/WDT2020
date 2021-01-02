using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IWorkStatusBL
    {
        IEnumerable<WorkStatus> getAllData();
        WorkStatus GetWorkStatusByID(int id);
    }
}
