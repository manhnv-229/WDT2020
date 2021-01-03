using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Model
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
        public Guid CustomerId { get; set; } 
        [Required("Mã khách hàng")]
        [CheckDuplicate("Mã khách hàng")]
        public string CustomerCode { get; set; }
        public string FullName { get; set; } 
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MemberCardCode { get; set; }
        public string Email { get; set; }
        [Required("Số điện thoại")]
        public string PhoneNumber { get; set; }
       

        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
    }
}
