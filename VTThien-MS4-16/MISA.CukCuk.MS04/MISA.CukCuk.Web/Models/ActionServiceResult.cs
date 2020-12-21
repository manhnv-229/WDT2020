using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.CukCuk.Web.Models.Enumarations;

namespace MISA.CukCuk.Web.Models
{
    public class ActionServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MISACode MISACode { get; set; }
        public object Data { get; set; }
    }
}
