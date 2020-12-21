using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI
{
    public class DbConnector
    {
        String connectionString = "User Id=nvmanh;password = 12345678;Host=103.124.92.43;port = 3306;Database = MS1_22_NDLuu_CukCuk;" +
                "Character Set=utf8";
        IDbConnection db;
        public DbConnector()
        {
            db = new MySqlConnection(connectionString);
        }

        public IEnumerable<T> GetAllData<T>()
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Get{tableName}s";
            var entity = db.Query<T>(store, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public IEnumerable<T> getByID<T>(string id){
            var tableName = typeof(T).Name;
            var store = $"Proc_Get{tableName}ByID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}ID", id);
            var entity = db.Query<T>(store, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;

        }
    }
}
