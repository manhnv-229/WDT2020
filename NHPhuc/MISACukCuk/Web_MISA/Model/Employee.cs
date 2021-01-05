using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_MISA.Model
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string CitizenIdentification { get; set; }
        public DateTime DateRange { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string PersonnalTax { get; set; }
        public string BasicSalary { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string JobPosition { get; set; }

    }
}
