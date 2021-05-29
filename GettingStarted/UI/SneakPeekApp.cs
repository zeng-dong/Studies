using GettingStarted.Data;
using GettingStarted.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GettingStarted.UI
{
    public class SneakPeekApp
    {
        private static SamuraiContext _context = new SamuraiContext();

        public static void Run(string[] args)
        {
            _context.Database.EnsureCreated();

            // see bulk operation
            AddSamuraisByName("S1", "S2", "S3", "S4");

            //GetSamurais("Before Add:");
            //AddSamurai();

            GetSamurais("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamuraisByName(params string[] names)
        {
            foreach (var name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }

            _context.SaveChanges();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Judie" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais
                .TagWith("SneakPeakApp GetSamurais()")
                .ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
