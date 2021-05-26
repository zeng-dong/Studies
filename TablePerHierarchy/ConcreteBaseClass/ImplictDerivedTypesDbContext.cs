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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=TPH_Implicit");

            // base.OnConfiguring(optionsBuilder);          /// the base method won't do anything more for you
        }
    }

    // so we can do: var tvContracts = context.Contracts.OfType<TvContract>().ToList();
}
