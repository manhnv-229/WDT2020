using Dapper;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data;
using Misa.BL.Entity;
using Misa.BL.Interface.IRepository;
using System.Collections.Generic;

namespace Misa.DL.CustomerRepository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {

        }

        
    }
}
