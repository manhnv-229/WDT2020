using Misa.BL.Emum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Result
{
    /// <summary>
    /// đối tượng quản lý dữ liệu trả về sau khi thao tác db
    /// </summary>
    public class ServiceResult
    {
        public object Data { get; set; }

        /// <summary>
        /// Danh sách thông báo trả về
        /// </summary>
        public List<string> Messenger { get; set; } = new List<string>();

        /// <summary>
        /// mã thông báo lỗi
        /// </summary>
        public MisaEmun MisaCode { get; set; }
    }
}
