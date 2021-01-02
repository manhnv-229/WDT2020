using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO
{
    public class PositionDAO : DbConnector, IPositionDAO
    {
        public IEnumerable<Position> getAllData()
        {
            var db = new DbConnector();
            return db.GetAllData<Position>();
        }

        public Position GetPositionByID(string id)
        {
            var db = new DbConnector();
            return db.getByID<Position>(id);
        }
    }
}
