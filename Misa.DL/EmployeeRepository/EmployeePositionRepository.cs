using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;

namespace Misa.DL.EmployeeRepository
{
    public class EmployeePositionRepository : BaseRepository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(IConfiguration config) : base(config)
        {

        }
    }
}
