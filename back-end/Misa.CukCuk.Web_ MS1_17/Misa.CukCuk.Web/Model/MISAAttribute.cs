using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Model
{
    public class MISAAttribute
    {
    }
    // attribute bat buoc nhap

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public string PropertyName; // ten cua property
        public string ErrorMessenger; // cau canh bao
        public Required(string propertyName, string errorMessage = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessage;
        }
    }
    // atrribute check trung ma
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

        public string PropertyName; // ten cua property
        public string ErrorMessenger; // cau canh bao
        public CheckDuplicate(string propertyName, string errorMessage = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessage;
        }
    }
}

