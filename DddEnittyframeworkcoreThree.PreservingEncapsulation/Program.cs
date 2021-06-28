using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Api;
using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation
{
    public class Program
    {
        public static void Main()
        {
            string result = string.Empty;

            //result = Execute(x => x.CheckStudentFavoriteCourse(1, 2));

            //result = Execute(x => x.AddEnrollment(1, 2, Grade.A));

            result = Execute(x => x.DisenrollStudent(1, 2));

            Console.WriteLine(result);
        }

        private static string Execute(Func<StudentController, string> func)
        {
            string connectionString = GetConnectionString();

            using (var context = new SchoolContext(connectionString, true))
            {
                var controller = new StudentController(context);
                return func(controller);
            }
        }


        private static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration["ConnectionString"];
        }
    }
}
