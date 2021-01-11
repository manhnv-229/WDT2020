using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string FullName { get; set; }

        public string MemberCardCode { get; set; }

        public Guid CustomerGroupId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyTaxCode { get; set; }
    }
}
