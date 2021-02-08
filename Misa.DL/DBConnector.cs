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

        #region get entity
        /// <summary>
        /// lấy danh sách bản ghi theo fielName(option)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="offSet"></param>
        /// <param name="limmit"></param>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>danh sách các bản ghi</returns>
        /// createdBy: Manh Tien (5/2/2021)
        public IEnumerable<T> GetData<T>(long page, long limmit, List<string> fieldNames = null, List<string> values = null)
        {
            long offSet;
            if (page == 1)
            {
                offSet = 0;
            }
            else
            {
                offSet = (page - 1) * limmit - 1;
            }
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@offSet", offSet);
            dynamicParameters.Add("@limmit", limmit);
            if (values == null)
            {
                var entities = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
            else
            {
                int index = 0;
                storeName += "By";
                Array _values = values.ToArray();
                foreach (var fieldName in fieldNames)
                {
                    storeName += $"{fieldName}";
                    dynamicParameters.Add($"@{fieldName}", _values.GetValue(index));
                    index++;
                }
                var entities = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
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
        #endregion

        /// <summary>
        /// thêm mới 1 bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>số bảng ghi được thêm mới</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        public int Insert<T>(T entity)
        {
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
                    if(propertyValue == null)
                    {
                        propertyValue = "";
                    }
                    else
                    {
                        propertyValue = propertyValue.ToString();
                    }
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

        #region count entity
        /// <summary>
        /// lấy tổng số bản ghi, không truyền tham số thì sẽ lấy tổng số bản ghỉ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>số lượng bản ghi: long</returns>
        /// createdBy: Manh Tien (5/2/2021)
        public long Count<T>(List<string> fieldNames = null, List<string> values = null)
        {
            var tableName = typeof(T).Name;
            if(values == null)
            {
                var storeName = $"Proc_Count{tableName}";
                long total = (long)dbConnection.ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
                return total;
            }
            else
            {
                string storeName = $"Proc_Count{tableName}By";
                DynamicParameters dynamicParameters = new DynamicParameters();
                Array _values = values.ToArray();
                int index = 0;
                if (fieldNames.Any() == false)
                {
                    return -1;
                }
                else
                {
                    foreach (var fieldName in fieldNames)
                    {
                        storeName = storeName + $"{fieldName}";
                        dynamicParameters.Add($"@{fieldName}", _values.GetValue(index));
                        index++;
                    }
                }
                long total = (long)dbConnection.ExecuteScalar(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
                return total;
            }
        }
        #endregion
    }
}
