using Dapper;
using Microsoft.Extensions.Configuration;
using Misa.BL.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk_3.DL
{
    public class DBConnector
    {
        protected string connectionString;
        protected IDbConnection dbConnection;
        readonly IConfiguration configuration;
        public DBConnector(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("mariaDB").Value;
            dbConnection = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// lấy danh toàn bộ bản ghi trong bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public IEnumerable<T> GetAllData<T>()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dbConnection.Query<T>(storeName,commandType:CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// lấy bản ghi theo id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>một bản ghi</returns>
        /// /// createdBy: Mạnh Tiến(26/12/2020)
        public T GetById<T>(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            var entity = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// thêm mới 1 bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>số bảng ghi được thêm mới</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Insert<T>(T entity)
        {
            var customer = entity as Customer;
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if(propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }

        /// <summary>
        /// cập nhật bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>số bản ghi được cập nhật</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Update<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    propertyValue = propertyValue.ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        }

        /// <summary>
        /// xóa bản ghi theo id của đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>số bản ghi bị xóa</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Delete<T>(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"{tableName}Id", id);
            var affect = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affect;
        }

        /// <summary>
        /// lấy bản ghi bằng câu lệnh sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns>danh sách bản ghi</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        public IEnumerable<T> GetData<T>(string sql)
        {
            var entity = dbConnection.Query<T>(sql);
            return entity;
        }

        /// <summary>
        /// lấy bản ghi theo phân trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="offSet"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sánh bản ghi</returns>
        public IEnumerable<T> GetTPaging<T>(int offSet, int limmit)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}Paging";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("offSet", offSet);
            dynamicParameters.Add("limmit", limmit);
            var entities = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// số lượng bản ghi trong 1 bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>số lượng bản ghi</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        public long Count<T>()
        {
            var tableName = typeof(T).Name;
            var storName = $"Proc_Count{tableName}";
            long total = (long)dbConnection.ExecuteScalar(storName, commandType: CommandType.StoredProcedure);
            return total;
        }
    }
}
