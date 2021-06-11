using GettingStarted.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace GettingStarted.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiAppDataFirstLook")

                //.LogTo(_writer.WriteLine)                  // delegate to StreamWriter.WriteLine
                //.LogTo(log => Debug.WriteLine(log))        // lambda expression for Debug.WriteLine 
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name })
                .EnableSensitiveDataLogging()
                ;
        }

        private StreamWriter _writer = new StreamWriter("EfcLog.txt", append: true);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
             .HasMany(s => s.Battles)
             .WithMany(b => b.Samurais)
             .UsingEntity<BattleSamurai>
              (bs => bs.HasOne<Battle>().WithMany(),
               bs => bs.HasOne<Samurai>().WithMany())
             .Property(bs => bs.DateJoined)
             .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Samurai>().OwnsOne(s => s.FullName);
        }

        /// No Track Queries and DbContext\
        /// var entities = _context.SomeSet.AsNoTracking()         // returns query, not dbset
        ///                     .FirstOrDefault();
        /// or in DbContext ctor:
        /// public ctor(){
        ///   ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;             // .TrackAll is the default
        /// }

    }
}
