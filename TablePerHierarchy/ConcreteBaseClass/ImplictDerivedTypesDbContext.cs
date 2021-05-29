using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TablePerHierarchy.ConcreteBaseClass
{
    public class ImplictDerivedTypesDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(
            builder =>
            {
                builder.AddConsole();
            });
        public DbSet<Contract> Contracts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MobileContract>();
            modelBuilder.Entity<TvContract>();
            modelBuilder.Entity<BroadBandContract>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=TPH_Implicit").EnableSensitiveDataLogging();

            // base.OnConfiguring(optionsBuilder);          /// the base method won't do anything more for you
        }
    }

    // so we can do: var tvContracts = context.Contracts.OfType<TvContract>().ToList();
}
