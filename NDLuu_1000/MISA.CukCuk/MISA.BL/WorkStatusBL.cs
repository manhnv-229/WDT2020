using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class WorkStatusBL : IWorkStatusBL
    {
        IWorkStatusDAO _workStatusDAO;
        public WorkStatusBL(IWorkStatusDAO workStatusDAO)
        {
            _workStatusDAO = workStatusDAO;
        }
        public IEnumerable<WorkStatus> getAllData()
        {
            return _workStatusDAO.getAllData();
        }

        public WorkStatus GetWorkStatusByID(int id)
        {
            return _workStatusDAO.GetWorkStatusByID(id);
        }
    }
}
