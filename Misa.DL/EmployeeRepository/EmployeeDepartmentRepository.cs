using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;

namespace Misa.DL.EmployeeRepository
{
    public class EmployeeDepartmentRepository : BaseRepository<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        public EmployeeDepartmentRepository(IConfiguration config) : base(config)
        {

        }
    }
}
