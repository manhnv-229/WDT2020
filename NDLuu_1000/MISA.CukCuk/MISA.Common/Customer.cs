using System;

namespace MISA.Common
{
    public class Customer
    {
        public Guid CustomerID { get; set; }

        public String CustomerCode { get; set; }

        public String FullName { get; set; }

        public String? MemberCardCode { get; set; }

        //public Guid CustomerGroupID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public String PhoneNumber { get; set; }

        public int? Gender { get; set; }

    }
}
