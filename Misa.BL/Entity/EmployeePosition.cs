using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// Đối tượng vị trí nhân viên
    /// </summary>
    public class EmployeePosition : BaseModel
    {
        #region properties
        /// <summary>
        /// id vị trí nhân viên
        /// </summary>
        public Guid EmployeePositionId { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string EmployeePositionName { get; set; }

        /// <summary>
        /// Mô tả vị trí
        /// </summary>
        public string EmployeePositionDescription { get; set; }

        /// <summary>
        /// Trách nhiệm vi trí
        /// </summary>
        public string EmployeePositionResponse { get; set; }

        /// <summary>
        /// Quyền lợi của vị trí 
        /// </summary>
        public string EmployeePositionInterests { get; set; }
        #endregion
    }
}
