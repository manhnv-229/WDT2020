using Dapper;
using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using System.Data;
using System.Collections.Generic;

namespace Misa.DL.EmployeeRepository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration config) : base(config)
        {

        }

        #region delete entity
        public int DeleteEmployeeByEmployeeCode(string code)
        {
            var storeName = $"Proc_DeleteEmployeeByEmployeeCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", code);
            int affect = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affect;
        }
        #endregion

        #region get employee code max
        public string GetEmployeeCodeMax()
        {
            var storeName = $"Proc_GetEmployeeCodeMax";
            string employeeCodeMax = (string)dbConnection.ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
            return employeeCodeMax;
        }
        #endregion
    }
}
