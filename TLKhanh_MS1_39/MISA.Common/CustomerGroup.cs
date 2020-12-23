using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifyAt { get; set; }
        public string ModifyBy { get; set; }
    }
}
