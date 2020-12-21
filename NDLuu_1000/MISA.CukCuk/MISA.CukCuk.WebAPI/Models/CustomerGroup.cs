using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI.Models
{
    public class CustomerGroup
    {
        public Guid CustomerGroupID { get; set; }

        public String CustomerGroupName { get; set; }

        public String Description { get; set; }
    }
}
