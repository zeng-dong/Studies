using Microsoft.EntityFrameworkCore;

namespace TablePerHierarchy.AbstractBaseClass
{
    public class AbstractBaseExplicitDerivedTypesDbContext : DbContext
    {
        public DbSet<MobileContract> MobileContracts { get; set; }
        public DbSet<TvContract> TvContracts { get; set; }
        public DbSet<BroadbandContract> BroadbandContracts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().ToTable("Contracts")

            /// optinal
            /// If you choose to provide your own values for the discriminator column, 
            /// you must provide values for all non-abstract entities in the mapped hierarchy. 
            /// The Contract entity in this example is abstract so it hasn't been included. 
            /// But if the base type is not defined as abstract, it must have a discriminator value provided.

            //.HasDiscriminator<int>("ContractType")
            //.HasValue<MobileContract>(1)
            //.HasValue<TvContract>(2)
            //.HasValue<BroadbandContract>(3);
            ;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=TPH_Explicit");

        }
    }
}
