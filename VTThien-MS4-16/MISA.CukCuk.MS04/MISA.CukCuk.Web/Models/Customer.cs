using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Models
{
    public class Customer
    {
        public string Fullname { get; set; }
        public string CustomerCode { get; set; }
        public Guid  CustomerId { get; set; }
        public string MemberCardCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Address { get; set; }
 

    }
}
