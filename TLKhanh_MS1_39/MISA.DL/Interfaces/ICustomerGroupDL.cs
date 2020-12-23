using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface ICustomerGroupDL
    {
        IEnumerable<CustomerGroup> GetAllCustomerGroup<CustomerGroup>();
        IEnumerable<CustomerGroup> GetCustomerGroupById<CustomerGroup>(string id);
        int InsertCustomerGroup(CustomerGroup customerGroup);
        int UpdateCustomerGroup(String id, CustomerGroup customerGroup);
        int DeleteCustomerGroup(String id);
        bool CheckCustomerGroupExists(string id);
    }
}
