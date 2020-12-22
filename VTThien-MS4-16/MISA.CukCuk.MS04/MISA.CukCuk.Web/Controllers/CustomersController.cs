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
        public IActionResult Get()
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
        /*[HttpGet]
        [Route("{id}")]
        public ActionServiceResult Get(int id)
        {
            var customer = Customer.Customers.Where(p => p.CustomerId == id).FirstOrDefault();
            return new ActionServiceResult()
            {
                Data = customer,
                Message = "Thành công",
                Success = true,
                MISACode = Enumarations.MISACode.Success
            };
        }
        [HttpGet]
        [Route("filter")]
        public ActionServiceResult Get2([FromQuery] int customerid, string customercode)
            {
                var find = Customer.Customers.Where(p => p.CustomerId == customerid && p.CustomerCode == customercode).FirstOrDefault();
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = "Thành công",
                    Data = find,
                    MISACode = Enumarations.MISACode.Success
                    
                };
            }
        
        /// <summary>
        /// thêm dữ liệu
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromBody] Customer customer)
        {
            Customer.Customers.Add(customer);
            return true;
        }

        /// <summary>
        /// sửa 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put([FromBody] Customer customer)
        {
            try
            {
                var findcustomer = Customer.Customers.Where(c => c.CustomerId == customer.CustomerId).FirstOrDefault();
                findcustomer.CompanyTaxCode = customer.CompanyTaxCode;
                findcustomer.FullName = customer.FullName;
                findcustomer.CustomerCode = customer.CustomerCode;
                findcustomer.MemberCardCode = customer.MemberCardCode;
                findcustomer.Gender = customer.Gender;
                findcustomer.Email = customer.Email;
                findcustomer.PhoneNumber = customer.PhoneNumber;
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// xóa theo mảng id
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete([FromBody] List<int> listID)
        {
            foreach (var item in listID)
            {
                var finditem = Customer.Customers.Where(c => c.CustomerId == item).FirstOrDefault();
                Customer.Customers.Remove(finditem);
            }
            return true;
        }*/
    }
}
