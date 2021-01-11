using Misa.BL.Emum;
using Misa.BL.Interface.IRepository;
using Misa.BL.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Misa.BL.ValidateData
{
    /// <summary>
    /// xác minh thôn tin trước khi lưu hoặc cập nhật
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// createdBy: Mạnh Tiến(27/12/2020)
    public class ValidateObj<T>
    {
        IBaseRepository<T> _baseRepository;
        public ValidateObj(IBaseRepository<T> repo)
        {
            _baseRepository = repo;
        }

        /// <summary>
        /// xác minh thôn tin trước khi lưu hoặc cập nhật
        /// </summary>
        /// <param name="model"></param>
        /// <returns>trả về kiểu serviceResult</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        public ServiceResult ValidateObject(T model, string id)
        {
            int flag = 0;
            var serviceResultInvalid = new ServiceResult();
            var serviceResultOk = new ServiceResult();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(model);
                if(property.IsDefined(typeof(Required), true) && (propertyValue == null || propertyValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if(requiredAttribute != null)
                    {
                        var proName = (requiredAttribute as Required).PropertyName;
                        var errorMess = (requiredAttribute as Required).ErrorMesseger;
                        serviceResultInvalid.Messenger.Add(errorMess == null ? $"{proName} không được trống" : errorMess);
                    }
                    serviceResultInvalid.MisaCode = MisaEmun.Invalid;
                    flag++;
                }

                if(property.IsDefined(typeof(CheckDup), true))
                {
                    string sql = $"SELECT {propertyName} FROM {typeof(T).Name} WHERE {propertyName}='{propertyValue}'";
                    string sql2 = $"SELECT {propertyName} FROM {typeof(T).Name} WHERE {propertyName}='{propertyValue}' AND {typeof(T).Name}Id='{id}'";
                    //id == null-thêm mới   id != null-cập nhật
                    if(id == null)
                    {
                        var entity = _baseRepository.GEtDataBySQL(sql).FirstOrDefault();
                        if (entity != null)
                        {
                            var checkDupAttribute = property.GetCustomAttributes(typeof(CheckDup), true).FirstOrDefault();
                            var proName = (checkDupAttribute as CheckDup).PropertyName;
                            var errorMess = (checkDupAttribute as CheckDup).ErrorMesseger;
                            serviceResultInvalid.Messenger.Add(errorMess == null ? $"{proName} đã tồn tại" : errorMess);
                            serviceResultInvalid.MisaCode = MisaEmun.Invalid;
                            flag++;
                        }
                    }
                    else
                    {
                        var entity = _baseRepository.GEtDataBySQL(sql).FirstOrDefault();
                        var entity2 = _baseRepository.GEtDataBySQL(sql2).FirstOrDefault();
                        if (entity2 == null  && entity != null)
                        {
                            var checkDupAttribute = property.GetCustomAttributes(typeof(CheckDup), true).FirstOrDefault();
                            var proName = (checkDupAttribute as CheckDup).PropertyName;
                            var errorMess = (checkDupAttribute as CheckDup).ErrorMesseger;
                            serviceResultInvalid.Messenger.Add(errorMess == null ? $"{proName} đã tồn tại" : errorMess);
                            serviceResultInvalid.MisaCode = MisaEmun.Invalid;
                            flag++;
                        }
                    }
                }
            }
            if(flag == 0)
            {
                serviceResultOk.Messenger.Add(Properties.Resources.Success);
                serviceResultOk.MisaCode = MisaEmun.Scuccess;
                return serviceResultOk;
            }
            return serviceResultInvalid;
        }
    }
}
