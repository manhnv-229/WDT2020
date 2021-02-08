using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    public class BaseModel
    {
        #region baseModel
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Count { get; set; }
        #endregion
    }
}
