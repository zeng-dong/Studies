using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specifications
{
    public class CustomerByLastnameSpec : Specification<Customer>
    {
        public CustomerByLastnameSpec(string lastname)
        {
            Query.Where(customer => customer.Lastname == lastname);
        }
    }

    public class CustomerByTypeSpec : Specification<Customer>
    {
        public CustomerByTypeSpec(string type)
        {
            Query.Where(customer => customer.CustomerType == Enumeration.FromDisplayName<CustomerType>(type));
        }
    }

    public class CustomerByIdSpec : Specification<Customer>, ISingleResultSpecification<Customer>
    {
        public CustomerByIdSpec(string id)
        {
            Query.Where(customer => customer.Id == id);
        }
    }
}