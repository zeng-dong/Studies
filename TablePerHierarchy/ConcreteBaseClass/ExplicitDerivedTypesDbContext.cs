using Microsoft.EntityFrameworkCore;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class ExplicitDerivedTypesDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<MobileContract> MobileContracts { get; set; }
        public DbSet<TvContract> TvContracts { get; set; }
        public DbSet<BroadBandContract> BroadBandContracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=TPH_Explicit").EnableSensitiveDataLogging()

            ;
            // base.OnConfiguring(optionsBuilder);          /// the base method won't do anything more for you
        }

    }

    // so we can do: var mobileContracts = context.MobileContracts.ToList();    
}
