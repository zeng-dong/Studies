using Mapping.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Mapping.Data
{
    public class SamuraiContext : DbContext
    {
        //public static readonly LoggerFactory MyConsoleLoggerFactory
        //   = new LoggerFactory(new[] {
        //      new ConsoleLoggerProvider((category, level)
        //        => category == DbLoggerCategory.Database.Command.Name
        //       && level == LogLevel.Information, true) });

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(
            builder =>
            {
                builder.AddConsole();
            });

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Samurai_Mapping; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });

            modelBuilder.Entity<Battle>().Property(b => b.StartDate).HasColumnType("Date");
            modelBuilder.Entity<Battle>().Property(b => b.EndDate).HasColumnType("Date");
            // base.OnModelCreating(modelBuilder);
        }
    }
}
