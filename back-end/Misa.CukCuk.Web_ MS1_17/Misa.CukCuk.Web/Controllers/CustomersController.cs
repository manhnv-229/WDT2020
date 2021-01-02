using Dapper;
using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Data;
using Misa.CukCuk.Web.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{

    public class CustomersController : BaseEntityController<Customer>
    {
        
        public override IEnumerable<Customer> Get()
        {
            var sql = "select * from Customer Limit 2";
          
            return _dbConnector.GetData<Customer>(sql);
        }
    }
}
