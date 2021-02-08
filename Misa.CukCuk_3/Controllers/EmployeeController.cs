using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using Misa.BL.Result;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Misa.CukCuk_3.Controllers
{
    public class EmployeeController : BaseEntityController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService empService) : base(empService)
        {
            _employeeService = empService;
        }


        [HttpGet("name/{fullName}/{page}/{limmit}")]
        public IEnumerable<Employee> GetEmployeesByName(string fullName, long page, long limmit)
        {
            var employees = _employeeService.GetEmployeesByName(fullName, page, limmit);
            return employees;
        }

        [HttpGet("position/{employeePosition}/{page}/{limmit}")]
        public IEnumerable<Employee> GetEmployeesByemployeePosition(string employeePosition, long page, long limmit)
        {
            var employees = _employeeService.GetEmployeesByEmployeePosition(employeePosition, page, limmit);
            return employees;
        }

        [HttpGet("department/{employeeDepartment}/{page}/{limmit}")]
        public IEnumerable<Employee> GetEmployeesByDepar(string employeeDepartment, long page, long limmit)
        {
            var employees = _employeeService.GetEmployeesByEmployeeDepartment(employeeDepartment, page, limmit);
            return employees;
        }

        [HttpGet("{employeePos}/{employeeDep}/{page}/{limmit}")]
        public IEnumerable<Employee> GetEmployeesPosAndDep(string employeePos, string employeeDep, long page, long limmit)
        {
            var employees = _employeeService.GetEmployeesByPositionAndDepartment(employeePos,employeeDep, page, limmit);
            return employees;
        }
        
        [HttpGet("countEmployeeByPosiIdAndDeparId/{posiId}/{deparId}")]
        public long CountEmployeeByPosiIdAndDeparId(string posiId, string deparId)
        {
            return _employeeService.CountEmployeeByPositionIdAndDepartmentId(posiId, deparId);
        }

        [HttpGet("countEmployeeByPosiId/{posiId}")]
        public long CountEmployeeByPosiId(string posiId)
        {
            return _employeeService.CountEmplyeeByEmployeePosiId(posiId);
        }

        [HttpGet("countEmployeeByDeparId/{deparId}")]
        public long CountEmployeeBDeparId(string deparId)
        {
            return _employeeService.CountEmplyeeByEmployeeDeparId(deparId);
        }

        [HttpGet("filter/{key}/{page}/{limmit}")]
        public IEnumerable<Employee> GetEmployeesResult(string key, long page, long limmit)
        {
            key = key.Trim();
            return _employeeService.SearchEmployee(key, page, limmit);
        }

        [HttpGet("countEmployeeByKey/{key}")]
        public long CountEmplooyeeByKey(string key)
        {
            return _employeeService.CountEmployeeByKey(key);
        }

        [HttpGet("employeeCode/{employeeCode}")]
        public Employee GetEmployeeByEmployeeCode(string employeeCode)
        {
            return _employeeService.GetEmployeeByEmployeeCode(employeeCode).FirstOrDefault();
        }

        [HttpGet("numberEmployeeSearchByName/{name}")]
        public long GetNumberEmployeeSearchByName(string name)
        {
            return _employeeService.CountEmployeeByName(name);
        }

        [HttpGet("employeeCodeMax")]
        public string GetEmployeeCodeMax()
        {
            return _employeeService.GetEmployeeCodeMax();
        }

        [HttpDelete("employeeCode/{code}")]
        public ServiceResult DeleteEmployeeByCode(string code)
        {
            return _employeeService.DeleteEmployeeByCode(code);
        }

        /*[HttpDelete("deleteEmployeeList")]
        public ServiceResult DeleteEmployeeByIdList([FromBody] List<string> ids)
        {
            return _employeeService.DeleteEmployeesByListId(ids);
        }*/

        [HttpPost("deleteEmployeeList")]
        public ServiceResult DeleteEmployeeByIdList([FromBody] List<string> ids)
        {
            return _employeeService.DeleteEmployeesByListId(ids);
        }

        [HttpPost("deleteEmployeeListByCode")]
        public ServiceResult DeleteEmployeeListByCode([FromBody] List<string> codes)
        {
            return _employeeService.DeleteEmployeeByListCode(codes);
        }
    }
}
