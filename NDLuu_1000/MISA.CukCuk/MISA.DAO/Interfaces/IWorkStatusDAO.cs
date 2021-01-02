using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface IWorkStatusDAO
    {
        IEnumerable<WorkStatus> getAllData();
        WorkStatus GetWorkStatusByID(int id);
    }
}
