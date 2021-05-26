using Microsoft.EntityFrameworkCore;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class ImplictDerivedTypesDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MobileContract>();
            modelBuilder.Entity<TvContract>();
            modelBuilder.Entity<BroadBandContract>();
        }
    }

    // so we can do: var tvContracts = context.Contracts.OfType<TvContract>().ToList();
}
