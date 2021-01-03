using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public String id { set {
                this.id = EmployeeID.ToString();
            } }
        public String EmployeeCode { get; set; }
        public String FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public String IdentityNumber { get; set; }
        public DateTime IdentityDate { get; set; }
        public String IdentityPlace { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public Guid PositionID { get; set; }
        public String PositionName { get; set; }
        public Guid DepartmentID { get; set; }
        public String DepartmentName { get; set; }
        public String TaxCode { get; set; }
        public double Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public int WorkStatusID { get; set; }
        public String WorkStatusName { get; set; }

    }
}
