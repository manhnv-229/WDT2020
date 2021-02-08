using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// đối tượng nhân viên
    /// </summary>
    public class Employee : BaseModel
    {
        #region properties

        /// <summary>
        /// id nhân viên
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required("Mã nhân viên")]
        [CheckDup("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required("Họ và tên")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Số cCMTND/thẻ căn cước công dân
        /// </summary>
        [Required("Số CMTND/ thẻ căn cước công dân")]
        [CheckDup("Số CMTND/ thẻ căn cước công dân")]
        public string EmployeeIDCard { get; set; }

        /// <summary>
        /// Ngày phát hành CMTND/thẻ căn cước công dân
        /// </summary>
        public DateTime? DateOfIssueIDCard { get; set; }

        /// <summary>
        /// Nơi phát hành thẻ CMTND/thể căn cước công dân
        /// </summary>
        public string IssueBy { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required("Email")]
        [CheckDup("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required("Số điện thoại")]
        [CheckDup("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// id vị trí nhân viên
        /// </summary>
        public Guid EmployeePositionId { get; set; }

        /// <summary>
        /// id bộ phận nhân viên
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Lương nhân viên
        /// </summary>
        public string EmployeeSalary { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        [CheckDup("Mã số thuế cá nhân")]
        public string EmployeeTaxCode { get; set; }

        /// <summary>
        /// Ngày gia nhập công ty
        /// </summary>
        public DateTime? DateOfJoiningCompany { get; set; }

        /// <summary>
        /// Trạng thái nhân viên
        /// </summary>
        public int EmployeeSate { get; set; }

        /// <summary>
        /// Vị trí nhân viên
        /// </summary>
        public string EmployeePositionName { get; set; }

        /// <summary>
        /// Bộ phận nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }
        #endregion
    }
}
