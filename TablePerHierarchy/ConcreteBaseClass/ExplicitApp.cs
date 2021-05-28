using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class ExplicitApp
    {
        private static ExplicitDerivedTypesDbContext _context = new ExplicitDerivedTypesDbContext();

        public static void Run()
        {
            _context.Database.EnsureCreated();

            AddContract();

            GetContracts();
        }

        private static void AddContract()
        {
            var contract = new Contract { Charge = 100, Months = 12, StartDate = DateTime.Now };
            _context.Contracts.Add(contract);

            var mobile = new MobileContract { Charge = 200, Months = 13, StartDate = DateTime.Now, MobileNumber = "713-c" };
            _context.Contracts.Add(mobile);

            mobile = new MobileContract { Charge = 200, Months = 13, StartDate = DateTime.Now, MobileNumber = "713-mc" };
            _context.MobileContracts.Add(mobile);

            var broadband = new BroadBandContract
            {
                Charge = 300,
                Months = 14,
                StartDate = DateTime.Now,
                DownloadSpeed = 555
            };
            _context.BroadBandContracts.Add(broadband);

            var tv = new TvContract { Charge = 400, Months = 15, StartDate = DateTime.Now, PackageType = PackageType.L };
            _context.TvContracts.Add(tv);

            _context.SaveChanges();

        }
        private static void GetContracts()
        {
            var contracts = _context.Contracts
                .TagWith("Explicit GetContracts()")
                .ToList();

            foreach (var contract in contracts)
            {
                Console.WriteLine(contract.StartDate.ToShortDateString() + ", " + contract.Months + ", " + contract.Charge);
            }
        }
    }
}
