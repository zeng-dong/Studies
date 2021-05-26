using Microsoft.EntityFrameworkCore;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class ExplicitDerivedTypesDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<MobileContract> MobileContracts { get; set; }
        public DbSet<TvContract> TvContracts { get; set; }
        public DbSet<BroadBandContract> BroadBandContracts { get; set; }
    }

    // so we can do: var mobileContracts = context.MobileContracts.ToList();
}
