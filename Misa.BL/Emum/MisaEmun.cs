using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Emum
{
    /// <summary>
    /// Misa code: xác định trạng thái valide data
    /// </summary>
    public enum MisaEmun
    {
        /// <summary>
        /// data hợp lệ
        /// </summary>
        Isvalid = 100,

        /// <summary>
        /// data không hợp lệ
        /// </summary>
        Invalid = 300,

        /// <summary>
        /// thành công
        /// </summary>
        Scuccess = 200,

        /// <summary>
        /// thất bại
        /// </summary>
        False = 600
    }

    public enum Gender
    {
        Male = 1,
        Female = 0,
        Other = 2
    }
}
