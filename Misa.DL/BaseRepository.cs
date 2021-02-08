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

        public IEnumerable<T> GEtDataBySQL(string sql)
        {
            return base.GetData<T>(sql);
        }

        public IEnumerable<T> GetData(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            return base.GetData<T>(page, limmit, fieldNames, values);
        }
        
        public int InsertEntity(T entity)
        {
            return base.Insert<T>(entity);
        }

        public int UpdateEntity(T entity)
        {
            return base.Update<T>(entity);
        }

        public long CountEntity(List<string> fieldNames = null, List<string> values = null)
        {
            return base.Count<T>(fieldNames, values);
        }

        public int DeleteEntity(string id)
        {
            return base.Delete<T>(id);
        }

    }
}
