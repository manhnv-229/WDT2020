using Misa.CukCuk.Web.Data;
using Misa.CukCuk.Web.Enum;
using Misa.CukCuk.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Services
{
    public class CustomerService
    {
        DatabaseConnector _databaseConnector;
        ServiceResult _serviceResult;
        public CustomerService()
        {
            _databaseConnector = new DatabaseConnector();
            _serviceResult = new ServiceResult();
        }
        public ServiceResult InsertCustomer(Customer customer)
        {
            //validate
            ValidateObject(customer);
            if (_serviceResult.MISACode == MISAServiceCode.BadRequest)
            {
                return _serviceResult;
            }
            // check trung ma
            var customerCode = customer.CustomerCode;
            var sql = $"select CustomerCode from Customer where CustomerCode = '{customerCode}'";
            var customerDuplicates = _databaseConnector.GetData<Customer>(sql);
            if (customerDuplicates.Count() > 0)
            {
                return new ServiceResult()
                {
                    Data = customerDuplicates,
                    Messenger = new List<string>{ Properties.Resources.Error_Duplicate },
                    MISACode = MISAServiceCode.BadRequest
                };
            }

            return new ServiceResult()
            {
                Data = _databaseConnector.Insert<Customer>(customer),
                Messenger = new List<string> { Properties.Resources.Msg_Success },
                MISACode = MISAServiceCode.Success
            };
        }
        private void ValidateObject(Customer customer)
        {
            var properties = typeof(Customer).GetProperties();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(customer);
                var propName = property.Name;
                // neu co attribute la [Required] thi kiem tra bat buoc nhap
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.Messenger.Add(errorMsg == null ? $"{propertyText} không được để trống. ": errorMsg);
                    }
                    _serviceResult.MISACode = MISAServiceCode.BadRequest;
                   
                }
                if (property.IsDefined(typeof(CheckDuplicate), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMsg = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        var sql = $"Select {propName}  from {typeof(Customer).Name} where {propName} = '{propValue}'";
                        var entity = _databaseConnector.GetData<Customer>(sql).FirstOrDefault();
                        if (entity != null) 
                        { 
                        _serviceResult.Messenger.Add(errorMsg == null ? $"{propertyText} đã tồn tại trên hệ thống nhoe" : errorMsg);
                        }
                    }
                    _serviceResult.MISACode = MISAServiceCode.BadRequest;

                }
            }
        }
    }
}
