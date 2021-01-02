using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DAO.Interfaces
{
    public interface IPositionDAO
    {
        IEnumerable<Position> getAllData();

        Position GetPositionByID(String id);
    }
}
