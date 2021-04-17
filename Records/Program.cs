using System;

namespace Records
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var classroomCourse = new Course(
                "Name Immutable",
                "Author Immutable"
                );
        }
    }

    public record Course(string Name, string Author);
}
