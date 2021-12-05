using System;
using System.Collections.Generic;

namespace Specifications
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var customers = new List<Customer>()
            {
                new Customer{ Id = "123", Lastname = "Zeng"},
                new Customer{ Id = "124", Lastname = "Ceng"},
                new Customer{ Id = "125", Lastname = "Zha"},
                new Customer{ Id = "126", Lastname = "Zeng"},
            };

            var spec = new CustomerByLastnameSpec("Zeng");

            var a = spec.Evaluate(customers);

            foreach (var customer in a)
                Console.WriteLine(customer.Id);
        }
    }
}