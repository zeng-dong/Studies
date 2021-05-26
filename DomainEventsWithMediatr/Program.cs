using DomainEventsWithMediatr.Interfaces;
using DomainEventsWithMediatr.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DomainEventsWithMediatr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Load Services");

            var services = ConfigureServices();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddMediatR(typeof(Program));
            //services.AddTransient<AppointmentSchedulingService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<App>();

            return services;
        }
    }
}
