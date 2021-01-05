using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Web_MISA
{
    public class DBConnector
    {
        string connectionString = "User Id=nvmanh;Host=103.124.92.43;Database = MS1_28_NHPhuc_CukCuk;port = 3306;password = 12345678;Character Set=utf8;";
        protected IDbConnection dbConnector;
        public DBConnector()
        {
            dbConnector = new MySqlConnection(connectionString);
        }
        public IEnumerable<T> GetAllData<T>()
        {

            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dbConnector.Query<T>(storeName, commandType: CommandType.StoredProcedure);
            return entity;
        }

        internal static object Query<T>(string v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<P> GetDataByCodeNamePhone<P>( string code, string name, string phone)
        {

            var tableName = typeof(P).Name;
            var storeName = $"Proc_Get{tableName}_By_Code_Name_PhoneNumber";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Code", code);
            dynamicParameters.Add($"@{tableName}Name", name);
            dynamicParameters.Add("@PhoneNumber", phone);
            var entity = dbConnector.Query<P>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        public int Insert<M>(M entity)
        {
            var tableName = typeof(M).Name;
            /*var customer = entity as Customer;*/
            var storeName = $"Proc_Insert_{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(M).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue.ToString());
            }
            var effects = dbConnector.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return effects;
        }
        public IEnumerable<T> DeleteEmployeeByCode<T>(string code)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_DeleteEmployee";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Code", code);
            var entity = dbConnector.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        public IEnumerable<T> UpdateEmployeeByCode<T>(string code)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_UpdateEmployeeByCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Code", code);
            var entity = dbConnector.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
