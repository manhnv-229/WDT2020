using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;
using Misa.BL.Emum;
using System.Collections.Generic;
using System.Linq;
using Misa.BL.Result;

namespace Misa.BL.ServiceImp
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository) : base(_employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        public long CountEmployeeByName(string name)
        {
            return employeeRepository.CountEmployeeResultSearchByName(name);
        }

        public long CountEmployeeByPositionIdAndDepartmentId(string posiId, string deparId)
        {
            return employeeRepository.CountEmplyeeByEmployeeIdAndEmployeeDeparId(posiId, deparId);
        }

        public long CountEmplyeeByEmployeeDeparId(string deparId)
        {
            return employeeRepository.CountEmplyeeByEmployeeDeparId(deparId);
        }

        public long CountEmplyeeByEmployeePosiId(string posiId)
        {
            return employeeRepository.CountEmplyeeByEmployeePosiId(posiId);
        }

        public ServiceResult DeleteEmployeeByCode(string code)
        {
            ServiceResult serviceResult = new ServiceResult();
            int affect = employeeRepository.DeleteEmployeeByEmployeeCode(code);
            if(affect == 0)
            {
                serviceResult.MisaCode = MisaEmun.False;
                serviceResult.Messenger.Add(Properties.Resources.Error_Delete);
            }
            else
            {
                serviceResult.MisaCode = MisaEmun.Scuccess;
                serviceResult.Messenger.Add("Đã xóa nhân viên: "+code);
            }
            return serviceResult;
        }

        public IEnumerable<Employee> GetEmployeeByEmail(string email)
        {
            return employeeRepository.GetEmployeeByEmail(email);
        }

        public IEnumerable<Employee> GetEmployeeByEmployeeCode(string code)
        {
            return employeeRepository.GetEmployeeByEmployeeCode(code);
        }

        public IEnumerable<Employee> GetEmployeeByIDCard(string idCard)
        {
            return employeeRepository.GetEmployeeByIDCard(idCard);
        }

        public IEnumerable<Employee> GetEmployeeByPhoneNumber(string phoneNumber)
        {
            return employeeRepository.GetEmployeeByPhoneNumber(phoneNumber);
        }

        public IEnumerable<Employee> GetEmployeeByTaxCode(string taxCode)
        {
            return employeeRepository.GetEmployeeByTaxCode(taxCode);
        }

        public string GetEmployeeCodeMax()
        {
            return employeeRepository.GetEmployeeCodeMax();
        }

        public IEnumerable<Employee> GetEmployeesByEmployeeDepartment(string employeeDepartmentId, int offSet, int limmit)
        {
            return employeeRepository.GetEmployeesByEmployeeDepartment(employeeDepartmentId, offSet, limmit);
        }

        public IEnumerable<Employee> GetEmployeesByEmployeePosition(string employeePositionId, int offSet, int limmit)
        {
            return employeeRepository.GetEmployeesByEmployeePosition(employeePositionId, offSet, limmit);
        }

        public IEnumerable<Employee> GetEmployeesByName(string name, int offSet, int limmit)
        {
            return employeeRepository.GetEmployeesByName(name, offSet, limmit);
        }

        public IEnumerable<Employee> GetEmployeesByPositionAndDepartment(string employeePositionId, string employeeDepartmentId, int offSet, int limmit)
        {
            return employeeRepository.GetEmployeesByPositionAndDepartment(employeePositionId, employeeDepartmentId, offSet, limmit);
        }
        public IEnumerable<Employee> SearchEmployee(string key, int offSet, int limmit)
        {
            var entites = employeeRepository.GetEmployeesByName(key, offSet, limmit);
            if(entites.Any() == true)
            {
                return entites;
            }
            else
            {
                entites = employeeRepository.GetEmployeeByEmployeeCode(key);
                if(entites.Any() == true)
                {
                    return entites;
                }
                else
                {
                    entites = employeeRepository.GetEmployeeByPhoneNumber(key);
                    return entites;
                }
                
            }
        }
    }
}
