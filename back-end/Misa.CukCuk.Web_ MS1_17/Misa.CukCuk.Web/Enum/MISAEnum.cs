using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Enum
{
    public enum MISAServiceCode
    {
        BadRequest = 400, // loi du lieu khong hop le
        Success = 200,
        Exception = 500
    }
    public enum Gender
    {
        Male = 1,
        Female = 0,
        Other = 2
    }
}
