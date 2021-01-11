using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.ValidateData
{
    class MisaAttribute
    {
    }
    /// <summary>
    /// Attribute để đánh dấu bắt buộc nhập
    /// </summary>
    /// createdBy: Mạnh Tiến(27/12/2020)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        /// <summary>
        /// tên của property được đánh dấu
        /// </summary>
        public string PropertyName;
        /// <summary>
        /// thông báo lỗi
        /// </summary>
        public string ErrorMesseger;

        public Required(string propertyName, string errorMessager = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMesseger = errorMessager;
        }
    }
    
    /// <summary>
    /// đánh dấu property cần check dup
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDup : Attribute
    {
        /// <summary>
        /// tên của property cần checkdup
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// thông báo lỗi
        /// </summary>
        public string ErrorMesseger;
        public CheckDup(string property, string errorMess = null)
        {
            this.PropertyName = property;
            this.ErrorMesseger = errorMess;
        }
    }
}
