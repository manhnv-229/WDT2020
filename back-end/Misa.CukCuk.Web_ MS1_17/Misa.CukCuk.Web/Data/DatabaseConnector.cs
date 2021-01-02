using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Data
{
    public class DatabaseConnector
    {
        public static string connectionString;  
      
        IDbConnection _dbconnection;
        public DatabaseConnector()
        {
            _dbconnection = new MySqlConnection(connectionString);
        }
        public IEnumerable<TEntity> GetAll<TEntity>()
        {
            string className = typeof(TEntity).Name;
            var sql = $"select * from {className}";
            var entities = _dbconnection.Query<TEntity>(sql);
            return entities;
        }
        public TEntity GetById<TEntity>(object id)
        {

            string className = typeof(TEntity).Name;
            var sql = $"select * from {className} where {className}Id='{id.ToString()}'";
            var entities = _dbconnection.Query<TEntity>(sql).FirstOrDefault();
            return entities;
        }

        public int Insert<TEntity>(TEntity entity)
        {
            string className = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties();
            var parameters = new DynamicParameters();
            var sqlPropetyBuilder = string.Empty;
            var sqlPropetyParamBuilder = string.Empty;
            foreach (var propety in properties)
            {
                var propertyName = propety.Name;
                var propertyValue = propety.GetValue(entity);
                parameters.Add($"@{propertyName}", propertyValue);
                sqlPropetyBuilder += $",{propertyName}";
                sqlPropetyParamBuilder += $",@{propertyName}";
            }
            var sql = $"Insert into {className}({sqlPropetyBuilder.Substring(1)}) VALUE ({sqlPropetyParamBuilder.Substring(1)})";
            var effectRows = _dbconnection.Execute(sql, parameters);
            return effectRows;
        }
    }
}
