using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.BL.Entity
{
    /// <summary>
    /// Nhóm khách hàng
    /// CreatedBy: Manh Tien(1/2/2021)
    /// </summary>
    public class CustomerGroup : BaseModel
    {
        #region properties

        /// <summary>
        /// id nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        #endregion
    }
}
