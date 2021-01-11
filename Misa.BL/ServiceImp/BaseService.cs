﻿using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Result;
using Misa.BL.Emum;
using System.Collections.Generic;
using System.Linq;
using Misa.BL.ValidateData;

namespace Misa.BL.ServiceImp
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> baseRepository;
        public BaseService(IBaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }

        public virtual long Count()
        {
            return baseRepository.CountEntity();
        }

        public ServiceResult DeleteT(string id)
        {
            var serviceResult = new ServiceResult();
            var tableName = typeof(T).Name;
            var sql = $"SELECT {tableName}Id FROM {typeof(T)} WHERE {tableName}Id = '{id}'";
            var entity = baseRepository.GEtDataBySQL(sql);
            if(entity.Any() == false)
            {
                serviceResult.Messenger.Add($"{typeof(T)}Id" + Properties.Resources.Error_NotExist);
                serviceResult.MisaCode = MisaEmun.False;
                return serviceResult;
            }
            else
            {
                var affect = baseRepository.DeleteEntity(id);
                serviceResult.Messenger.Add(Properties.Resources.Success);
                serviceResult.MisaCode = MisaEmun.Scuccess;
                return serviceResult;
            }
        }

        public T GetTById(string id)
        {
            return baseRepository.GetEntityById(id);
        }

        public IEnumerable<T> GetTPaging(int offSet, int limmit)
        {
            return baseRepository.GetEntityPaging(offSet, limmit);
        }

        public IEnumerable<T> GetTs()
        {
            return baseRepository.GetEntitys();
        }

        public ServiceResult InsertT(T entity)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResult = validateObj.ValidateObject(entity, null);
            if(serviceResult.MisaCode == MisaEmun.Scuccess)
            {
                var affect = baseRepository.InsertEntity(entity);
            }
            return serviceResult;
            
        }

        public ServiceResult UpdateT(T entity, string id)
        {
            var validateObj = new ValidateObj<T>(baseRepository);
            var serviceResult = validateObj.ValidateObject(entity, id);
            if (serviceResult.MisaCode == MisaEmun.Scuccess)
            {
                var affect = baseRepository.UpdateEntity(entity);
            }
            return serviceResult;
        }
    }
}
