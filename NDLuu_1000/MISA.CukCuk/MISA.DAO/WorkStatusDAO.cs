using Dapper;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DAO
{
    public class WorkStatusDAO : DbConnector, IWorkStatusDAO
    {
        public IEnumerable<WorkStatus> getAllData()
        {
            var db = new DbConnector();
            return db.GetAllData<WorkStatus>();
        }

        public WorkStatus GetWorkStatusByID(int id)
        {
            var Store = "Proc_GetWorkStatusByID";
            var entity = db.Query<WorkStatus>(Store,id, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }
    }
}
