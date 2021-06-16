using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Data;
using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation
{
    public class Program
    {
        public static void Main()
        {
            string connectionString = GetConnectionString();
            bool useConsoleLogger = true;  // IHostingEnvironment.IsDevelopment()

            using (var context = new SchoolContext(connectionString, useConsoleLogger))
            {
                //Student student = context.Students.Find(1L);

                Student student = context.Students
                    //.Include(x => x.FavoriteCourse)
                    .SingleOrDefault(x => x.Id == 1);
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
