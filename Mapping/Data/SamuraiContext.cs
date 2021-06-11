using Mapping.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mapping.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 "Server = (localdb)\\mssqllocaldb; Database = Samurai_Mapping; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });

            // base.OnModelCreating(modelBuilder);
        }
    }
}
