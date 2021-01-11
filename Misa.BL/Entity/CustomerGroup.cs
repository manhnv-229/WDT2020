using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.BL.Entity
{
    public class CustomerGroup : BaseModel
    {
        public Guid CustomerGroupId { get; set; }

        public string CustomerGroupName { get; set; }
    }
}
