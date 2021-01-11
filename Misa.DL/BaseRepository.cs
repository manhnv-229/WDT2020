using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.CukCuk_3.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL
{
    public class BaseRepository<T> : DBConnector, IBaseRepository<T>
    {
        public BaseRepository(IConfiguration config) : base(config)
        {

        }

        public long CountEntity()
        {
            return base.Count<T>();
        }

        public int DeleteEntity(string id)
        {
            return base.Delete<T>(id);
        }

        public IEnumerable<T> GEtDataBySQL(string sql)
        {
            return base.GetData<T>(sql);
        }

        public T GetEntityById(string id)
        {
            return base.GetById<T>(id);
        }

        public IEnumerable<T> GetEntityPaging(int offSet, int limmit)
        {
            return base.GetTPaging<T>(offSet, limmit);
        }

        public IEnumerable<T> GetEntitys()
        {
            return base.GetAllData<T>();
        }

        public int InsertEntity(T entity)
        {
            return base.Insert<T>(entity);
        }

        public int UpdateEntity(T entity)
        {
            return base.Update<T>(entity);
        }
    }
}
