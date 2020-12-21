using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Models
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string MemberCardCode { get; set; }
        public Guid CustomerGroupId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        public int  CustomerId { get; set; }
       /* public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }*/
        static List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                CustomerCode = "KH0001",
                FullName = "Vũ Thanh Thiên",
                MemberCardCode = "ABc",
                Email = "thudan.td@gmail.com",
                CustomerId=123,
            },
            new Customer()
            {
                CustomerCode = "KH0002",
                FullName = "Vũ  Thiên",
                MemberCardCode = "ABc",
                Email = "thun.td@gmail.com",
                CustomerId=1234,
            },
            new Customer()
            {
                CustomerCode = "KH03",
                FullName = " Thiên",
                MemberCardCode = "ABc",
                Email = "than.td@gmail.com",
                CustomerId=12345,
            }
        };
        public static List<Customer> Customers {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
            }
        }

    }
}
