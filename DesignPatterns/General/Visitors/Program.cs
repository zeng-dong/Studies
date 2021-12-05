using System;
using System.Collections.Generic;

namespace Visitors
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Object> items = new List<object>
            {
                new Book(12345, 11.99),
                new Book(78910, 22.79),
                new Vinyl(11198, 17.99),
                new Book(66634, 9.99)
            };
        }
    }
}