using Misa.CukCuk.Web.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Model
{
    public class ServiceResult
    {
        public object Data { get; set; }
        public List<string> Messenger { get; set; } = new List<string>();
        // ma ket qua
        public MISAServiceCode MISACode { get; set; }
    }
}
