using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// Đối tượng bộ phận nhân viên
    /// </summary>
    public class EmployeeDepartment : BaseModel
    {
        #region properties
        /// <summary>
        /// id bộ phận nhân viên
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên bộ phận nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        /// <summary>
        /// Mô tả bộ phận nhân viên
        /// </summary>
        public string EmployeeDepartmentDescription { get; set; }
        #endregion
    }
}
