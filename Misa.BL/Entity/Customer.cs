using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// Đối tượng khách hàng
    /// CreatedBy: Mạnh Tiến(1/2/2021)
    /// </summary>
    public class Customer : BaseModel
    {
        #region properties
        /// <summary>
        /// id khách hàng
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// mã khách hàng
        /// </summary>
        [Required("Mã khách hàng")]
        [CheckDup("Mã khách hàng")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ tên khách hàng
        /// </summary>
        [Required("Họ và tên")]
        [CheckDup("Họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Mã thành viên
        /// </summary>
        [Required("Mã thành viên")]
        [CheckDup("Mã thành viên")]
        public string MemberCardCode { get; set; }

        /// <summary>
        /// id nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [Required("Email")]
        [CheckDup("Email")]
        public string Email { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        [Required("Số điện thoại")]
        [CheckDup("Số điên thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// mã số  thuế khách hàng
        /// </summary>
        [Required("Mã thuế công ty khách hàng")]
        [CheckDup("Mã thuế công ty khách hàng")]
        public string CompanyTaxCode { get; set; }
        #endregion
    }
}
