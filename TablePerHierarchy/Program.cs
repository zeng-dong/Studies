using System;
using TablePerHierarchy.ConcreteBaseClass;

namespace TablePerHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Explicit");
            ExplicitApp.Run();

            Console.WriteLine("Implicit");
            ImplicitApp.Run();

            Console.ReadLine();
        }
    }
}
