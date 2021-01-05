using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Gender { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}

