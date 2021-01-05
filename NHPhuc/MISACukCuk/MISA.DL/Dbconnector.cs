using Dapper;
using MISA.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class Dbconnector
    {
        string connectionString = "User Id=nvmanh;Host=103.124.92.43;Database = MS1_28_NHPhuc_CukCuk;port = 3306;password = 12345678;Character Set=utf8;";
        protected IDbConnection db;
        public Dbconnector()
        {
            db = new MySqlConnection(connectionString);
        }
        public IEnumerable<T> GetAllData<T>()
        {

            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = db.Query<T>(storeName, commandType:CommandType.StoredProcedure);
            return entity;
        }
        public IEnumerable<P> GetByID<P>(string id)
        {

            var tableName = typeof(P).Name;
            var storeName = $"Proc_Get{tableName}s_By_ID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}ID", id);
            var entity = db.Query<P>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        public IEnumerable<P> GetDataByPhoneAndCode<P>(string phone, string code)
        {

            var tableName = typeof(P).Name;
            var storeName = $"Proc_Get{tableName}By_Phone_And_Code";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("PhoneNumberContains", phone);
            dynamicParameters.Add($"@{tableName}CodeContains", code);
            var entity = db.Query<P>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public int Insert<M>(M entity)
        {
            var tableName = typeof(M).Name;
            var customer = entity as Customer;
            var storeName = $"Proc_Insert_{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(M).GetProperties();
            foreach(var property in properties)
            {
                var propertyName = property.Name    ;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue.ToString());
            }
            var effects = db.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return effects;
        }
    }
}
