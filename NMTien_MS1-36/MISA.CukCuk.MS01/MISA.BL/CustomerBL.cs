using MISA.Common;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class CustomerBL
    {
        public int InsertCustomer(Customer customer)
        {
            CustomerDL customerDL = new CustomerDL();
            //1. check trùng mã:
            if(customerDL.CheckDuplicateCustomerCode(customer.CustomerCode) == true)
            {
                return -1;
            }
            else
            {
                var effectRows = customerDL.InsertCustomer(customer);
                return effectRows;
            }

            //2. check trùng sđt:

           
        }
    }
}
