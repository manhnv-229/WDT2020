using Dapper;
using MISA.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DAO
{
    public class DbConnector
    {
        //Khởi tạo chuỗi kết nối
        protected String connectionString = "User Id=nvmanh;password = 12345678;Host=103.124.92.43;port = 3306;Database = MS1_22_NDLuu_CukCuk;" +
                "Character Set=utf8";
        protected IDbConnection db;
        //Hàm khơi tạo
        public DbConnector()
        {
            db = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Lấy tất cả bản ghi của bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public IEnumerable<T> GetAllData<T>()
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Get{tableName}s";
            var entity = db.Query<T>(store, commandType: CommandType.StoredProcedure).ToList();
            return entity;
        }

        /// <summary>
        /// Lấy bản ghi theo mã
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>Một bản ghi</returns>
        public T getByID<T>(string id){
            var tableName = typeof(T).Name;
            var store = $"Proc_Get{tableName}ByID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}ID", id);
            var entity = db.Query<T>(store, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;

        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Insert{tableName}";
            var result = db.Execute(store , entity, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
