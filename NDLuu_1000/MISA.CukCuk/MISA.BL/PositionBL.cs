using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class PositionBL : IPositionBL
    {
        IPositionDAO _positionDAO;
        public PositionBL(IPositionDAO positionDAO)
        {
            _positionDAO = positionDAO;
        }
        public IEnumerable<Position> getAllData()
        {
            return _positionDAO.getAllData();
        }

        public Position GetPositionByID(string id)
        {
            return _positionDAO.GetPositionByID(id);
        }
    }
}
