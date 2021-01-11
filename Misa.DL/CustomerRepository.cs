using Dapper;
using Microsoft.Extensions.Configuration;
using Misa.CukCuk_3.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Misa.BL.Entity;
using Misa.BL.Interface.IRepository;
using Misa.BL.Result;

namespace Misa.DL
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {

        }
        public Customer GetCustomerByCustomerCode(string code)
        {
            var storeName = $"Proc_GetCustomerByCustomerCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@CustomerCode", code);
            var customer = dbConnection.Query<Customer>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }

        public Customer GetCustomerByEmail(string email)
        {
            var storeName = $"Proc_GetCustomerByEmail";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Email", email);
            var customer = dbConnection.Query<Customer>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }

        public Customer GetCustomerbyPhoneNumber(string phoneNumber)
        {
            var storeName = $"Proc_GetCustomerbyPhoneNumber";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@PhoneNumber", phoneNumber);
            var customer = dbConnection.Query<Customer>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }
        
    }
}
