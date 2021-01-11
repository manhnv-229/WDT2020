using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    public class Customer : BaseModel
    {
        public Guid CustomerId { get; set; }

        [Required("Mã khách hàng")]
        [CheckDup("Mã khách hàng")]
        public string CustomerCode { get; set; }


        [Required("Họ và tên")]
        [CheckDup("Họ và tên")]
        public string FullName { get; set; }

        [Required("Mã thành viên")]
        [CheckDup("Mã thành viên")]
        public string MemberCardCode { get; set; }

        public Guid CustomerGroupId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }

        [Required("Email")]
        [CheckDup("Email")]
        public string Email { get; set; }

        [Required("Số điện thoại")]
        [CheckDup("Số điên thoại")]
        public string PhoneNumber { get; set; }

        [Required("Mã thuế công ty khách hàng")]
        [CheckDup("Mã thuế công ty khách hàng")]
        public string CompanyTaxCode { get; set; }
    }
}
