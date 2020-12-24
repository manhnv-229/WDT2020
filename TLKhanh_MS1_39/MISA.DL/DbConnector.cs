using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace MISA.DL
{
    public class DbConnector 
    {
        protected string connectionString = "User Id=nvmanh;Host=103.124.92.43;port=3306;password=12345678;database=MS1_39_Khanh_CukCuk;Character Set=utf8";
        protected IDbConnection dbConnection;
        public DbConnector()
        {
            dbConnection = new MySqlConnection(connectionString);
        }

        public IEnumerable<TEntity> GetAllData<TEntity>()
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dbConnection.Query<TEntity>(storeName, commandType: CommandType.StoredProcedure);
            return entity;
        }
        public IEnumerable<TEntity> GetById<TEntity>(string id)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);

            var entity = dbConnection.Query<TEntity>(
                storeName, 
                dynamicParameters, 
                commandType: CommandType.StoredProcedure
                );
            return entity;
        }
        public int Insert<TEntity>(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Insert{tableName}";
            var properties = typeof(TEntity).GetProperties();

            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var propertie in properties)
            {
                var propertyName = propertie.Name;
                var propertyValue = propertie.GetValue(entity);

                if(propertyName == "CustomerGroupId")
                {
                    propertyValue = propertie.GetValue(entity).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }

            var affectedRows = dbConnection.Execute(
                storeName, 
                dynamicParameters, 
                commandType: CommandType.StoredProcedure
                );
            return affectedRows;
        }
        public int DeleteById<TEntity>(string id)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Delete{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            var affectedRows = dbConnection.Execute(
                storeName, 
                dynamicParameters, 
                commandType: CommandType.StoredProcedure
                );
            return affectedRows;
        }
        public int UpdateById<TEntity>(string id, TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var storeName = $"Proc_Update{tableName}ById";
            var properties = typeof(TEntity).GetProperties();

            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var propertie in properties)
            {
                var propertyName = propertie.Name;
                var propertyValue = propertie.GetValue(entity);
                if (propertyName == "CustomerGroupId")
                {
                    propertyValue = propertie.GetValue(entity).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            dynamicParameters.Add($"@{tableName}Id", id);

            var affectedRows = dbConnection.Execute(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
                );
            return affectedRows;
        }

    }
}
