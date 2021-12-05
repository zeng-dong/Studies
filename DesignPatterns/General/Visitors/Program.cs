using System;
using System.Collections.Generic;

namespace Visitors
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //BookStoreProgram.Run();

            PersonProgram.Run();
        }
    }
}

// visitors let you define a new operation without changing the classes of the elements on which it operates

// represent an operation to be performed on the elements of an object structure