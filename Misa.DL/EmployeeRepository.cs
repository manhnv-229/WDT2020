using Dapper;
using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace Misa.DL
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration config) : base(config)
        {

        }

        public long CountEmployeeResultSearchByName(string name)
        {
            var storeName = $"Proc_CountEmployeeResultSearchByName";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeName", name);
            long count = (long)dbConnection.ExecuteScalar(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return count;
        }

        public long CountEmplyeeByEmployeeDeparId(string deparId)
        {
            var storeName = $"Proc_CountEmployeeByEmployeeDepartment";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeDepartmentId", deparId);
            long count = (long)dbConnection.ExecuteScalar(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return count;
        }

        public long CountEmplyeeByEmployeePosiId(string posiId)
        {
            var storeName = $"Proc_CountEmployeeByEmployeePosition";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeePositionId", posiId);
            long count = (long)dbConnection.ExecuteScalar(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return count;
        }

        public long CountEmplyeeByEmployeeIdAndEmployeeDeparId(string posiId, string deparId)
        {
            var storeName = $"Proc_CountEmployeePositionAndDepartment";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeePositionId", posiId);
            dynamicParameters.Add($"@EmployeeDepartmentId", deparId);
            long count = (long)dbConnection.ExecuteScalar(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return count;
        }

        public int DeleteEmployeeByEmployeeCode(string code)
        {
            var storeName = $"Proc_DeleteEmployeeByEmployeeCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", code);
            int affect = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affect;
        }

        public IEnumerable<Employee> GetEmployeeByEmail(string email)
        {
            var storeName = $"Proc_GetEmployeeByEmail";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Email", email);
            var employee = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeByEmployeeCode(string code)
        {
            var storeName = $"Proc_GetEmployeeByEmployeeCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", code);
            var employee = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeByIDCard(string idCard)
        {
            var storeName = $"Proc_GetEmployeeByEmployeeIDCard";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeIDCard", idCard);
            var employee = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeByPhoneNumber(string phoneNumber)
        {
            var storeName = $"Proc_GetEmployeeByPhoneNumber";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@PhoneNumber", phoneNumber);
            var employee = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeByTaxCode(string taxCode)
        {
            var storeName = $"Proc_GetEmployeeByEmployeeTaxCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeTaxCode", taxCode);
            var employee = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return employee;
        }

        public string GetEmployeeCodeMax()
        {
            var storeName = $"Proc_GetEmployeeCodeMax";
            string employeeCodeMax = (string)dbConnection.ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
            return employeeCodeMax;
        }

        public IEnumerable<Employee> GetEmployeesByEmployeeDepartment(string employeeDepartmentId, int offSet, int limmit)
        {
            var storeName = $"Proc_GetEmployeesByEmployeeDepartment";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeDepartmentId", employeeDepartmentId);
            dynamicParameters.Add($"@offSet", offSet);
            dynamicParameters.Add($"@limmit", limmit);
            var entities = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        public IEnumerable<Employee> GetEmployeesByEmployeePosition(string employeePositionId, int offSet, int limmit)
        {
            var storeName = $"Proc_GetEmployeesByEmployeePosition";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeePositionId", employeePositionId);
            dynamicParameters.Add($"@offSet", offSet);
            dynamicParameters.Add($"@limmit", limmit);
            var entities = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        public IEnumerable<Employee> GetEmployeesByName(string name, int offSet, int limmit)
        {
            var storeName = $"Proc_GetEmployeesByEmployeeName";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeName", name);
            dynamicParameters.Add($"@offSet", offSet);
            dynamicParameters.Add($"@limmit", limmit);
            var entities = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        public IEnumerable<Employee> GetEmployeesByPositionAndDepartment(string employeePositionId, string employeeDepartmentId, int offSet, int limmit)
        {
            var storeName = $"Proc_GetEmployeesByPositionAndDepartment";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeDepartmentId", employeeDepartmentId);
            dynamicParameters.Add($"@EmployeePositionId", employeePositionId);
            dynamicParameters.Add($"@offSet", offSet);
            dynamicParameters.Add($"@limmit", limmit);
            var entities = dbConnection.Query<Employee>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

    }
}
