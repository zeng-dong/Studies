using GettingStarted.Data;
using GettingStarted.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                _context.Samurais.Add(new Samurai { FirstName = name });
            }

            _context.SaveChanges();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { FirstName = "Judie" };
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
                Console.WriteLine(samurai.FirstName);
            }
        }

        private static void QueryFilters()
        {
            var filter = "J%";
            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.FirstName, filter)).ToList();
        }

        private static void QueryAndUpdateBattles_Disconnected()
        {
            List<Battle> disconnectedBattles;
            using (var context1 = new SamuraiContext())
            {
                disconnectedBattles = _context.Battles.ToList();
            } //context1 is disposed

            disconnectedBattles.ForEach(b =>
            {
                b.StartDate = new DateTime(1570, 01, 01);
                b.EndDate = new DateTime(1570, 12, 1);
            });

            using (var context2 = new SamuraiContext())
            {
                context2.UpdateRange(disconnectedBattles);
                context2.SaveChanges();
            }
        }
    }
}
