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
}