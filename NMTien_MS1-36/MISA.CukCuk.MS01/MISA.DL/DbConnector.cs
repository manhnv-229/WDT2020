using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
namespace MISA.DL
{
    public class DbConnector
    {
        protected string connectionString = "Host=103.124.92.43; User Id= nvmanh;" + "password=12345678;Database=36_NguyenManhTien_CukCuk;Character Set=utf8";
        protected IDbConnection dbConnection;
        public DbConnector()
        {
            dbConnection = new MysqlConnection(connectionString);
        }
        public IEnumerable<M> GetAllData<M>()
        {
            var tableName = typeof(M).Name;
            var storeName = $"Proc_Get{tableName}"; 
            var entity = dbConnection.Query<M>(storeName,commandType:CommandType.StoredProcedure);
            return entity;
            
        }
        public IEnumerable<M> GetById<M>(string id)
        {
            var tableName = typeof(M).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters(); //tham so động
            dynamicParameters.Add($"@{tableName}Id", id);
            var entity = dbConnection.Query<M>(storeName,dynamicParameters ,commandType: CommandType.StoredProcedure);
            return entity;

        }
        public IEnumerable<M> GetDataByCodeAndPhone<M>(string code, string phone)
        {
            var tableName = typeof(M).Name;
            var storeName = $"Proc_Get{tableName}ByCodeAndPhone";
            DynamicParameters dynamicParameters = new DynamicParameters(); //tham so động
            dynamicParameters.Add($"@CustomerCodeContains",code);
            dynamicParameters.Add($"@PhoneNumberContains", phone);
            var entity = dbConnection.Query<M>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;

        }
        public int Insert<M>(M entity)
        {
            var tableName = typeof(M).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Đọc các property:
            var properties = typeof(M).GetProperties();
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}",propertyValue);

            }
            var affects = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affects;
        } 
    }
}
