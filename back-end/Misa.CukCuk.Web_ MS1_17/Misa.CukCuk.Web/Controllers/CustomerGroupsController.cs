using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Data;
using Misa.CukCuk.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupsController : BaseEntityController<CustomerGroup>
    {
        
    }
}
