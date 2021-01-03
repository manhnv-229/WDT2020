using Dapper;
using MISA.Common;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DAO
{
    public class EmployeeDAO : DbConnector, IEmployeeDAO
    {
        /// <summary>
        /// Check trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode"> Mã nhân viên</param>
        /// <returns>True nếu trùng, False nếu k trùng</returns>
        /// CreatedBy NDLuu (29/12/2020)
        public bool checkDuplicateEmployeeCode(string employeeCode)
        {
            var x = db.Query<Employee>($"Select * from Employee where EmployeeCode = '{employeeCode}'").FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Xoá Nhân Viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmployee(string id)
        {
            var sql = $"Delete From Employee Where EmployeeID = '{id}'";
            var e = db.Execute(sql);
            return e;
        }

        /// <summary>
        /// Lấy nhân viên theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeByID(string id)
        {
            var db = new DbConnector();
            return db.getByID<Employee>(id);
        }

        /// <summary>
        /// Lấy Tất cả Nhân Viên
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            var db = new DbConnector();
            return db.GetAllData<Employee>();
        }

        /// <summary>
        /// Thêm mới nhân Viên
        /// </summary>
        /// <param name="employee">Nhân Viên</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        /// Author: NDLuu (3/1/2021)
        public int InsertEmployee(Employee employee)
        {
            var store = "Proc_InsertEmployee";
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("@EmployeeCode", employee.EmployeeCode.ToString());
            dynamic.Add("@FullName", employee.FullName);
            dynamic.Add("@DateOfBirth", employee.DateOfBirth);
            dynamic.Add("@Gender", employee.Gender);
            dynamic.Add("@IdentityNumber", employee.IdentityNumber);
            dynamic.Add("@IdentityDate", employee.IdentityDate);
            dynamic.Add("@IdentityPlace", employee.IdentityPlace);
            dynamic.Add("@Email", employee.Email);
            dynamic.Add("@PhoneNumber", employee.PhoneNumber);
            dynamic.Add("@PositionID", employee.PositionID.ToString());
            dynamic.Add("@DepartmentID", employee.DepartmentID.ToString());
            dynamic.Add("@TaxCode", employee.TaxCode);
            dynamic.Add("@Salary", employee.Salary);
            dynamic.Add("@JoinDate", employee.JoinDate);
            dynamic.Add("@WorkStatusID", employee.WorkStatusID);
            var effectRow = db.Execute(store, dynamic,commandType:CommandType.StoredProcedure);
            return effectRow;
        }

        /// <summary>
        /// Cập nhật Nhân Viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Số bản ghi được cập nhật</returns>
        public int UpdateEmployee(Employee employee)
        {
            var em = getByID<Employee>(employee.EmployeeID.ToString());
            var sql = $"Update Employee set EmployeeCode = '{employee.EmployeeCode}' , " +
                $"FullName = '{employee.FullName}'," +
                $" Gender = {employee.Gender}," +
                $" IdentityNumber = '{employee.IdentityNumber}'," +
                $" IdentityPlace = '{employee.IdentityPlace}'," +
                $" Email = '{employee.Email}'," +
                $"PhoneNumber = '{employee.PhoneNumber}'," +
                $"PositionID = '{employee.PositionID}'," +
                $"DepartmentID = '{employee.DepartmentID}'," +
                $"Salary = {employee.Salary}," +
                $"TaxCode = '{employee.TaxCode}'," +
                $"WorkStatusID = {employee.WorkStatusID}" +
                $" where EmployeeID = '{employee.EmployeeID.ToString()}'";

            /*var em = getByID<Employee>(employee.EmployeeID.ToString());
            var store = "Proc_UpdateEmployee";

            var entity = db.Execute(store, em, commandType: CommandType.StoredProcedure);*/
            var e = db.Execute(sql);
            return e;
        }
    }
}
