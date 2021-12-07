using System;
using System.Collections.Generic;
using System.Linq;

namespace Specifications
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var customers = new List<Customer>()
            {
                new Customer{ Id = "123", Lastname = "Zeng", CustomerType = CustomerType.Best },
                new Customer{ Id = "124", Lastname = "Ceng", CustomerType = CustomerType.Best},
                new Customer{ Id = "125", Lastname = "Zha", CustomerType = CustomerType.Better},
                new Customer{ Id = "126", Lastname = "Zeng", CustomerType = CustomerType.Good},
            };

            var spec = new CustomerByLastnameSpec("Zeng");
            var a = spec.Evaluate(customers);
            foreach (var customer in a)
                Console.WriteLine(customer.Id);

            var spec2 = new CustomerByTypeSpec("Best");
            var b = spec2.Evaluate(customers);
            foreach (var customer in b)
                Console.WriteLine(customer.Id);

            var spec3 = new CustomerByIdSpec("123");
            var c = spec3.Evaluate(customers).SingleOrDefault();
            Console.WriteLine(c.Id + " - " + c.Lastname);
        }
    }
}