using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Intefaces
{
    public interface ICustomerGroupBL
    {
        IEnumerable<CustomerGroup> GetAllCustomerGroup<CustomerGroup>();
        IEnumerable<CustomerGroup> GetCustomerGroupById<CustomerGroup>(string id);
        int InsertCustomerGroup(CustomerGroup customerGroup);
        int UpdateCustomerGroup(String id, CustomerGroup customerGroup);
        int DeleteCustomerGroup(String id);
    }
}
