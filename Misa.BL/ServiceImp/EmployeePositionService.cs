using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Entity;

namespace Misa.BL.ServiceImp
{
    public class EmployeePositionService : BaseService<EmployeePosition>, IEmployeePositionService
    {
        IEmployeePositionRepository _repo;
        public EmployeePositionService(IEmployeePositionRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
