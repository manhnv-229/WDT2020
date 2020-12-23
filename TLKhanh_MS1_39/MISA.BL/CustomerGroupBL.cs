using MISA.BL.Intefaces;
using MISA.Common;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class CustomerGroupBL : ICustomerGroupBL
    {
        ICustomerGroupDL _customerGroupDL;
        public CustomerGroupBL(ICustomerGroupDL customerGroupDL)
        {
            _customerGroupDL = customerGroupDL;
        }
        public int DeleteCustomerGroup(string id)
        {
            if (_customerGroupDL.CheckCustomerGroupExists(id) == true)
            {
                return _customerGroupDL.DeleteCustomerGroup(id);

            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<CustomerGroup> GetAllCustomerGroup<CustomerGroup>()
        {
            return _customerGroupDL.GetAllCustomerGroup<CustomerGroup>();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroupById<CustomerGroup>(string id)
        {
            if (_customerGroupDL.CheckCustomerGroupExists(id) == true)
            {
                return _customerGroupDL.GetCustomerGroupById<CustomerGroup>(id);
            }
            else
            {
                return null;
            }
        }

        public int InsertCustomerGroup(CustomerGroup customerGroup)
        {
            return _customerGroupDL.InsertCustomerGroup(customerGroup);
        }

        public int UpdateCustomerGroup(string id, CustomerGroup customerGroup)
        {
            if (_customerGroupDL.CheckCustomerGroupExists(id) == true)
            {
                return _customerGroupDL.UpdateCustomerGroup(id, customerGroup);
            }
            else
            {
                return 0;
            }
        }
    }
}
