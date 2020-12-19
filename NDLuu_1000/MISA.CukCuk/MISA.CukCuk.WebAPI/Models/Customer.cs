using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI.Models
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public String CustomerCode { get; set; }
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }
    }
}
