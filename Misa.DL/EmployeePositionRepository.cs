using Microsoft.Extensions.Configuration;
using Misa.BL.Interface.IRepository;
using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL
{
    public class EmployeePositionRepository : BaseRepository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(IConfiguration config) : base(config)
        {

        }
    }
}
