using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interfaces
{
    public interface IPositionBL
    {
        IEnumerable<Position> getAllData();

        Position GetPositionByID(String id);
    }
}
