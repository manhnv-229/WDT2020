using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    public class EmployeePosition : BaseModel
    {
        public Guid EmployeePositionId { get; set; }
        public string EmployeePositionName { get; set; }
        public string EmployeePositionDescription { get; set; }
        public string EmployeePositionResponse { get; set; }
        public string EmployeePositionInterests { get; set; }
    }
}
