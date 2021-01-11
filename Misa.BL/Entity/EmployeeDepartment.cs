using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    public class EmployeeDepartment : BaseModel
    {
        public Guid EmployeeDepartmentId { get; set; }
        public string EmployeeDepartmentName { get; set; }
        public string EmployeeDepartmentDescription { get; set; }
    }
}
