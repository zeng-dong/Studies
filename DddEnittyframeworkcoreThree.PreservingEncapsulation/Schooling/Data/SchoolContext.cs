﻿using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Data
{
    public sealed class SchoolContext : DbContext
    {
        private readonly string _connectionString;
        private readonly bool _useConsoleLogger;

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolContext(string connectionString, bool useConsoleLogger)
        {
            _connectionString = connectionString;
            _useConsoleLogger = useConsoleLogger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

            optionsBuilder
                .UseSqlServer(_connectionString)
                .UseLazyLoadingProxies()
                ;


            if (_useConsoleLogger)
            {
                optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(x =>
            {
                x.ToTable("Student").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("StudentID");
                x.Property(p => p.Email)
                    .HasConversion(p => p.Value, p => Email.Create(p).Value);


                // x.Property(p => p.Name)  // replaced with OwnsONe                    
                ;

                x.OwnsOne(p => p.Name, p =>
                {
                    p.Property(pp => pp.First).HasColumnName("FirstName");
                    p.Property(pp => pp.Last).HasColumnName("LastName");
                });

                //x.Property(p => p.FavoriteCourseId);         
                x.HasOne(p => p.FavoriteCourse).WithMany();  // setup m2o with navigation property, not fk

                x.HasMany(p => p.Enrollments).WithOne(p => p.Student)

                    .OnDelete(DeleteBehavior.Cascade)

                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field)
                ;

            });

            modelBuilder.Entity<Suffix>(x =>
            {
                x.ToTable("Suffix").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("SuffixID");
                x.Property(p => p.Name)
                ;
            });

            modelBuilder.Entity<Course>(x =>
            {
                x.ToTable("Course").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("CourseID");
                x.Property(p => p.Name)
                    .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore)
                ;
            });
            modelBuilder.Entity<Enrollment>(x =>
            {
                x.ToTable("Enrollment").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("EnrollmentID");
                x.HasOne(p => p.Student).WithMany(p => p.Enrollments);
                x.HasOne(p => p.Course).WithMany();
                x.Property(p => p.Grade);
            });
        }

        public override int SaveChanges()
        {
            foreach (EntityEntry<Course> course in ChangeTracker.Entries<Course>())
            {
                course.State = EntityState.Unchanged;
            }

            return base.SaveChanges();
        }
    }
}
