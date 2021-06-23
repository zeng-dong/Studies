using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Api;
using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Data;
using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation
{
    public class Program
    {
        public static void Main()
        {
            //string result = Execute(x => x.CheckStudentFavoriteCourse(1, 2));

            string result = Execute(x => x.AddEnrollment(1, 2, Grade.A));

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
