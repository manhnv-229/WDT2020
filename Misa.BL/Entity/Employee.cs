using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    public class Employee : BaseModel
    {
        public Guid EmployeeId { get; set; }

        [Required("Mã nhân viên")]
        [CheckDup("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        [Required("Họ và tên")]
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }

        [Required("Số CMTND/ thẻ căn cước công dân")]
        [CheckDup("Số CMTND/ thẻ căn cước công dân")]
        public string EmployeeIDCard { get; set; }

        public DateTime? DateOfIssueIDCard { get; set; }
        public string IssueBy { get; set; }

        [Required("Email")]
        [CheckDup("Email")]
        public string Email { get; set; }

        [Required("Số điện thoại")]
        [CheckDup("Số điện thoại")]
        public string PhoneNumber { get; set; }
        public Guid EmployeePositionId { get; set; }
        public Guid EmployeeDepartmentId { get; set; }
        public string EmployeeSalary { get; set; }

        [CheckDup("Mã số thuế cá nhân")]
        public string EmployeeTaxCode { get; set; }
        public DateTime? DateOfJoiningCompany { get; set; }
        public int EmployeeSate { get; set; }

        public string EmployeePositionName { get; set; }
        public string EmployeeDepartmentName { get; set; }
    }
}
