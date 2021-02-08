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

        #region count employee
        public long CountEmployeeByKey(string key)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeName");
            values.Add(key);
            long quantity = employeeRepository.CountEntity(fieldNames, values);
            if (quantity != 0)
            {
                return quantity;
            }
            fieldNames.Clear();
            fieldNames.Add("EmployeeCode");
            var resultSearchByCode = employeeRepository.GetData(0, 1, fieldNames, values);
            if(resultSearchByCode.Any() == true)
            {
                return 1;
            }
            fieldNames.Clear();
            fieldNames.Add("Phonenumber");
            var resultSearchByPhoneNumber = employeeRepository.GetData(0, 1, fieldNames, values);
            if (resultSearchByPhoneNumber.Any() == true)
            {
                return 1;
            }
            return 0;
        }

        public long CountEmployeeByName(string name)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeName");
            values.Add(name);
            return employeeRepository.CountEntity(fieldNames, values);
        }

        public long CountEmployeeByPositionIdAndDepartmentId(string posiId, string deparId)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeePositionId");
            fieldNames.Add("EmployeeDepartmentId");
            values.Add(posiId);
            values.Add(deparId);
            return employeeRepository.CountEntity(fieldNames, values);
        }

        public long CountEmplyeeByEmployeeDeparId(string deparId)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeDepartmentId");
            values.Add(deparId);
            return employeeRepository.CountEntity(fieldNames, values);
        }

        public long CountEmplyeeByEmployeePosiId(string posiId)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeePositionId");
            values.Add(posiId);
            return employeeRepository.CountEntity(fieldNames, values);
        }
        #endregion

        #region delete employee
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

        public ServiceResult DeleteEmployeeByListCode(List<string> codes)
        {
            ServiceResult serviceResult = new ServiceResult();
            foreach (var code in codes)
            {
                var result = DeleteEmployeeByCode(code);
                if(result.MisaCode == MisaEmun.False)
                {
                    serviceResult.MisaCode = MisaEmun.False;
                    serviceResult.Messenger.Add(Properties.Resources.Error_Delete);
                    return serviceResult;
                }
                else
                {
                    serviceResult.Messenger.Add("Đã xóa nhân viên " + code);
                }
            }
            serviceResult.MisaCode = MisaEmun.Scuccess;
            return serviceResult;
        }

        public ServiceResult DeleteEmployeesByListId(List<string> ids)
        {
            int count = 0;
            var serviceResult = new ServiceResult();
            foreach (var id in ids)
            {
                DeleteT(id);
                count++;
            }
            serviceResult.Data = count;
            serviceResult.MisaCode = MisaEmun.Scuccess;
            serviceResult.Messenger.Add(Properties.Resources.Success);
            return serviceResult;
        }
        #endregion

        #region get employee
        public IEnumerable<Employee> GetEmployeeByEmail(string email)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("Email");
            values.Add(email);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeeByEmployeeCode(string code)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeCode");
            values.Add(code);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeeByIDCard(string idCard)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeByIDCard");
            values.Add(idCard);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeeByPhoneNumber(string phoneNumber)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("PhoneNumber");
            values.Add(phoneNumber);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeeByTaxCode(string taxCode)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeTaxCode");
            values.Add(taxCode);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public string GetEmployeeCodeMax()
        {
            return employeeRepository.GetEmployeeCodeMax();
        }

        public IEnumerable<Employee> GetEmployeesByEmployeeDepartment(string employeeDepartmentId, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeDepartmentId");
            values.Add(employeeDepartmentId);
            return employeeRepository.GetData(page, limmit, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeesByEmployeePosition(string employeePositionId, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeePositionId");
            values.Add(employeePositionId);
            return employeeRepository.GetData(page, limmit, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeesByName(string name, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeName");
            values.Add(name);
            return employeeRepository.GetData(page, limmit, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeesByPositionAndDepartment(string employeePositionId, string employeeDepartmentId, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeePositionId");
            values.Add(employeePositionId);
            fieldNames.Add("EmployeeDepartmentId");
            values.Add(employeeDepartmentId);
            return employeeRepository.GetData(page, limmit, fieldNames, values);
        }
        #endregion

        public IEnumerable<Employee> SearchEmployee(string key, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeName");
            values.Add(key);
            var entites = employeeRepository.GetData(page, limmit, fieldNames, values);
            if (entites.Any() == true)
            {
                return entites;
            }
            else
            {
                fieldNames.Clear();
                fieldNames.Add("EmployeeCode");
                entites = employeeRepository.GetData(0, 1, fieldNames, values);
                if (entites.Any() == true)
                {
                    return entites;
                }
                else
                {
                    fieldNames.Clear();
                    fieldNames.Add("Phonenumber");
                    entites = employeeRepository.GetData(0, 1, fieldNames, values);
                    return entites;
                }
                
            }
        }
    }
}
