using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Web.Models;
using MySql.Data.MySqlClient;
using Nuke.Common.Tooling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var  customers = new List<Customer>();
            string connectionstring = "User Id=nvmanh;Host=103.124.92.43;Database=MS4_16_VuThanhThien_CukCuk;port=3306;password=12345678; Character Set=utf8";
            using (IDbConnection dbConnection = new MySqlConnection(connectionstring))
            {   
                //lay du lieu
                customers = dbConnection.Query<Customer>("Select * from Customer").ToList();
                return Ok(new ActionServiceResult()
                {
                    Success = true,
                    Message = "Thành công",
                    Data = customers,
                    MISACode = Enumarations.MISACode.Success

                });
            }
                      /*      return customers;*/
        }
        ///get dữ liệu all

        /*[HttpGet]
        public ActionServiceResult Get()
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                Data = Customer.Customers,
                MISACode = Enumarations.MISACode.Success

            };
        }*/

        /// <summary>
        /// get dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById([FromRoute]Guid customerId)
        {
            var customer = new Customer();
            string connectionstring = "User Id=nvmanh;Host=103.124.92.43;Database=MS4_16_VuThanhThien_CukCuk;port=3306;password=12345678; Character Set=utf8";
            using (IDbConnection dbConnection = new MySqlConnection(connectionstring))

            {
                var sqlQuery = $"Proc_GetCustomerByID";
                customer = dbConnection.Query<Customer>(sqlQuery, 
                    new {CustomerID = customerId.ToString() }, 
                    commandType:CommandType.StoredProcedure).FirstOrDefault();
            };
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                Data = customer,
                MISACode = Enumarations.MISACode.Success

            });
        }

        [HttpGet("byid/filter")]
        public IActionResult Get([FromQuery] string customerCode, [FromQuery] string phoneNumber)
        {
            var customers = new List<Customer>();
            string connectionstring = "User Id=nvmanh;Host=103.124.92.43;Database=MS4_16_VuThanhThien_CukCuk;port=3306;password=12345678; Character Set=utf8";
            using (IDbConnection dbConnection = new MySqlConnection(connectionstring))

            {
                var sqlQuery = $"Proc_GetCustomerByNameAndCode";
                customers = dbConnection.Query<Customer>(sqlQuery, 
                    new { CodeContains = customerCode, PhoneContains = phoneNumber }, 
                    commandType: CommandType.StoredProcedure).ToList();
            };
            return Ok(new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                Data = customers,
                MISACode = Enumarations.MISACode.Success

            });
        }

        [HttpPost]
        public IActionResult CreateNewCustomer([FromBody] Customer customer)
        {
            var insertCustomer = 0;
            string connectionstring = "User Id=nvmanh;Host=103.124.92.43;Database=MS4_16_VuThanhThien_CukCuk;port=3306;password=12345678; Character Set=utf8";
            using (IDbConnection dbConnection = new MySqlConnection(connectionstring))
            {
                var sqlQuery = $"Proc_InsertCustomer";
                customer.CustomerID = Guid.NewGuid();
                var param = new
                {
                    CustomerID = customer.CustomerID.ToString(),
                    CustomerCode = customer.CustomerCode,
                    FullName = customer.FullName,
                    MemberCardCode = customer.MemberCardCode,
                    CustomerGroupID = customer.CustomerGroupID.ToString(),
                    DateOfBirth = customer.DateOfBirth,
                    Gender = customer.Gender.HasValue == true? customer.Gender : 0,
                    Email = string.IsNullOrEmpty(customer.Email)==true? "" : customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    CompanyName = customer.CompanyName,
                    CompanyTaxCode = customer.CompanyTaxCode,
                    CreatedBy = "vtthien",
                    ModifiedBy = "vtthen",
                    Address = customer.Address
                };
                insertCustomer = dbConnection.Execute(sqlQuery,
                    param,
                    commandType: CommandType.StoredProcedure);
            }

            // thêm mới thành công
            if (insertCustomer > 0)
            {
                return Ok(customer);
            }

            // thất bại trả về 400 - badrequest
            return BadRequest();
        }
    }
}
