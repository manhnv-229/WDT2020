using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_MISA.Controllers.Model
{
    public class Customer
    {
        public static string SchoolName="HUMG";
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }

        public string Field;
        public string MyProperty { get; set; }

    }
}
